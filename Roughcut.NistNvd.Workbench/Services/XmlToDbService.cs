using System.Xml;
using System.Xml.Serialization;
using Roughcut.NistNvd.Workbench.DbContexts;
using Roughcut.NistNvd.Workbench.DbModels;


namespace Roughcut.NistNvd.Workbench.Services
{
    public class XmlToDbService
    {
        // create dbcontext
        AppDbContext _dbContext = new AppDbContext();

        // create notification delegate for progress
        public delegate void NotifyProgress(string message);
        public event NotifyProgress NotifyProgressEvent;

        // create total and current progress variables
        private int _totalProgress;
        private int _currentProgress;

        // create elapsed time variable
        public TimeSpan ElapsedTime { get; private set; }
        public DateTime _startTime;
        private DateTime _currenTime;
        public DateTime _endTime;


        // constructor
        public XmlToDbService() { }
        
        public void ImportXmlToDb(string sourceFullPath)
        {

            // init progress
            _totalProgress = 0;

            // initialize elapsed time variables
            _startTime = DateTime.Now;
            _endTime = DateTime.Now;
 

            // create that we're loading the source xml file
            NotifyProgressEvent?.Invoke($"Loading source xml file: {sourceFullPath}");

            // Step 1: open file stream for large xml file
            // create stream to read large xml file to prevent out of memory exception
            FileStream fileStream = new FileStream(sourceFullPath, FileMode.Open, FileAccess.Read);

            // load the xml document using the file stream
            XmlDocument doc = new XmlDocument();
            doc.Load(fileStream);

            // get the document element
            XmlElement root = doc.DocumentElement;

            // get the child nodes of the document element
            XmlNodeList childNodes = root.ChildNodes;

            // get total number of child nodes for progress
            _totalProgress = childNodes.Count;
            _currentProgress = 0;

            // create message getting distinct list of cpeitem-titles from database for comparison
            NotifyProgressEvent?.Invoke($"Getting distinct list of cpeitem-titles from database for comparison");

            // get distinct list of cpeitem-names from database for comparison
            // todo: review dbmodels and logic to properly handle nulls, assuming nulls are not allowed
            List<string?> cpeItemNames = _dbContext.CpeItems.Select(c => c.Name)
                .Where(c => c != null)
                .Distinct()
                .ToList();

            // create total to process message
            NotifyProgressEvent?.Invoke($"Total to process: {_totalProgress}");

            // loop through the child nodes and convert to cpeitem json
            foreach (XmlNode childNode in childNodes)
            {
                // increment current progress
                _currentProgress++;

                // create progress message
                NotifyProgressEvent?.Invoke($"Processing {_currentProgress} of {_totalProgress}");

                // notify of current elapsed time after every 5000 items
                if (_currentProgress % 10000 == 0)
                {
                    // create current elapsed time message
                    _currenTime = DateTime.Now;
                    ElapsedTime = _currenTime - _startTime;
                    NotifyProgressEvent?.Invoke($"Elapsed time: {ElapsedTime}");

                    // pause for 1.5 second
                    System.Threading.Thread.Sleep(1500);
                }

                // step over xmlnode if is "generator" - for initial versions
                if (childNode.Name == "generator")
                {
                    continue;
                }
                else
                {
                    // get the title of the cpeitem
                    string title = childNode["title"].InnerText;
                    string cpeItemName = childNode.Attributes["name"].Value;
                    // check if the title already exists in cpeItemTitles list
                    if (cpeItemNames.Contains(cpeItemName))
                    {
                        // create message that cpeitem already exists and is being skipped
                        NotifyProgressEvent?.Invoke($"\rCpeItem already exists: {title} - skipping.");

                        continue;
                    }
                }

                // create message that cpeitem is being added to database
                NotifyProgressEvent?.Invoke($"\rAdding CpeItem to database: {childNode["title"].InnerText}");


                // appears to be new cpeitem, so deserialize the child node to a CpeItem object
                CpeItem cpeItem = null;
                XmlSerializer serializer = new XmlSerializer(typeof(CpeItem));
                using (StringReader reader = new StringReader(childNode.OuterXml))
                {
                    cpeItem = (CpeItem)serializer.Deserialize(reader);
                    
                }

                // add to database, if not null
                if (cpeItem == null)
                {
                    // todo: log error
                    continue;
                }

                // add to database
                _dbContext.CpeItems.Add(cpeItem);
                _dbContext.SaveChanges();

            }

            // create completed message
            NotifyProgressEvent?.Invoke("Processing completed.");

        }

    }
}

using System.Runtime.CompilerServices;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Schema;
using System.Xml;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Roughcut.NistNvd.Workbench.Services;
using Formatting = Newtonsoft.Json.Formatting;

namespace Roughcut.NistNvd.Workbench
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            // get current project directory
            string currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine($"Current Directory: {currentDirectory}");
            // get current project directory
            string vsProjectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            Console.WriteLine($"Project Directory: {vsProjectDirectory}");
            // get current project directory
            string solutionDirectory = Directory.GetParent(vsProjectDirectory).Parent.FullName;
            Console.WriteLine($"Solution Directory: {solutionDirectory}");
            // get current project directory
            string vsProjDataDropZoneDirectory = Path.Combine(vsProjectDirectory, "data-files");
            Console.WriteLine($"Data Files Directory: {vsProjDataDropZoneDirectory}");

            // create dropzone directory if it doesn't exist
            if (!Directory.Exists(vsProjDataDropZoneDirectory))
            {
                Directory.CreateDirectory(vsProjDataDropZoneDirectory);
            }


            // write getting started message
            Console.WriteLine("Getting started...");

            // use this url to download zip file
            // https://nvd.nist.gov/feeds/xml/cpe/dictionary/official-cpe-dictionary_v2.3.xml.zip

            // get source zip file from nist nvd, drop into data-files folder
            string zipFileUrl = "https://nvd.nist.gov/feeds/xml/cpe/dictionary/official-cpe-dictionary_v2.3.xml.zip";


            // write zip file url to console
            Console.WriteLine($"Zip File URL: {zipFileUrl}");

            // write downloading message to console
            Console.WriteLine($"Downloading {zipFileUrl}...");

            // download zip file
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync(zipFileUrl).Result;

            // save the file to disk
            string zipFilePath = $@"{vsProjDataDropZoneDirectory}\official-cpe-dictionary_v2.3.xml.zip";

            // delete zip file if it exists
            if (File.Exists(zipFilePath))
            {
                File.Delete(zipFilePath);
            }

            // write download complete message to console
            Console.WriteLine($"Download complete. Saving to {zipFilePath}...");

            // save the file to disk
            using (var fileStream = new FileStream(zipFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                response.Content.CopyToAsync(fileStream).Wait();
            }

            // delete source xml file if it exists
            string sourceXmlFilePath = $@"{vsProjDataDropZoneDirectory}\official-cpe-dictionary_v2.3.xml";
            if (File.Exists(sourceXmlFilePath))
            {
                File.Delete(sourceXmlFilePath);
            }

            // write unzip message to console
            Console.WriteLine($"Unzipping {zipFilePath}...");

            // unzip the file
            System.IO.Compression.ZipFile.ExtractToDirectory(zipFilePath, vsProjDataDropZoneDirectory);

            // create xml to db service
            XmlToDbService xmlToDbService = new XmlToDbService();

            // register event handler
            xmlToDbService.NotifyProgressEvent += (message) =>
            {
                // possible future-state for implementing an improved console output
                // https://stackoverflow.com/questions/888533/how-can-i-update-the-current-line-in-a-csharp-windows-console-app
                // https://pvq.app/questions/888533/how-can-i-update-the-current-line-in-a-csharp-windows-console-app

                Console.WriteLine("\r" + message);
                
            };

            // import xml to db
            xmlToDbService.ImportXmlToDb(sourceXmlFilePath);

            // pause after processing
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }


    }
}

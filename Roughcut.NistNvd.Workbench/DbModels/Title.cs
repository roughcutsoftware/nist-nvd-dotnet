using System.Xml.Serialization;
using Roughcut.NistNvd.Workbench.Base;

namespace Roughcut.NistNvd.Workbench.DbModels
{

    [XmlRoot(ElementName = "title", Namespace = "http://cpe.mitre.org/dictionary/2.0")]
    public class Title : EntityBase
    {
        [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
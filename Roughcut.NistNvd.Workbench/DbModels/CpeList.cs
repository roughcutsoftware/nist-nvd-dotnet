using System.Xml.Serialization;
using Roughcut.NistNvd.Workbench.Base;

namespace Roughcut.NistNvd.Workbench.DbModels
{
    /* 
     Licensed under the Apache License, Version 2.0

     http://www.apache.org/licenses/LICENSE-2.0
     */

    [XmlRoot(ElementName = "cpe-list", Namespace = "http://cpe.mitre.org/dictionary/2.0")]
    public class CpeList : EntityBase
    {
        [XmlElement(ElementName = "generator", Namespace = "http://cpe.mitre.org/dictionary/2.0")]
        public Generator Generator { get; set; }

        [XmlElement(ElementName = "cpe-item", Namespace = "http://cpe.mitre.org/dictionary/2.0")]
        public List<CpeItem> CpeItem { get; set; }

        [XmlAttribute(AttributeName = "config", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Config { get; set; }

        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }

        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }

        [XmlAttribute(AttributeName = "scap-core", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Scapcore { get; set; }

        [XmlAttribute(AttributeName = "cpe-23", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Cpe23 { get; set; }

        [XmlAttribute(AttributeName = "ns6", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns6 { get; set; }

        [XmlAttribute(AttributeName = "meta", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Meta { get; set; }

        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
    }
}

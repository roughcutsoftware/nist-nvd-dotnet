using System.Xml.Serialization;
using Roughcut.NistNvd.Workbench.Base;

namespace Roughcut.NistNvd.Workbench.DbModels
{
    [XmlRoot(ElementName = "cpe-item", Namespace = "http://cpe.mitre.org/dictionary/2.0")]
    public class CpeItem : EntityBase
    {
        [XmlElement(ElementName = "title", Namespace = "http://cpe.mitre.org/dictionary/2.0")]
        public Title Title { get; set; }

        [XmlElement(ElementName = "references", Namespace = "http://cpe.mitre.org/dictionary/2.0")]
        public References? References { get; set; }

        [XmlElement(ElementName = "cpe23-item", Namespace = "http://scap.nist.gov/schema/cpe-extension/2.3")]
        public Cpe23item? Cpe23item { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string? Name { get; set; }

        [XmlAttribute(AttributeName = "deprecated")]
        public string? Deprecated { get; set; }

        [XmlAttribute(AttributeName = "deprecation_date")]
        public string? Deprecation_date { get; set; }
    }
}
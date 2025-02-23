using System.Xml.Serialization;
using Roughcut.NistNvd.Workbench.Base;

namespace Roughcut.NistNvd.Workbench.DbModels;

[XmlRoot(ElementName = "cpe23-item", Namespace = "http://scap.nist.gov/schema/cpe-extension/2.3")]
public class Cpe23item : EntityBase
{
    [XmlAttribute(AttributeName = "name")]
    public string Name { get; set; }

    [XmlElement(ElementName = "deprecation", Namespace = "http://scap.nist.gov/schema/cpe-extension/2.3")]
    public Deprecation? Deprecation { get; set; }
}
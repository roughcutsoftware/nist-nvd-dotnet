using System.Xml.Serialization;
using Roughcut.NistNvd.Workbench.Base;

namespace Roughcut.NistNvd.Workbench.DbModels;

[XmlRoot(ElementName = "deprecated-by", Namespace = "http://scap.nist.gov/schema/cpe-extension/2.3")]
public class Deprecatedby : EntityBase
{
    [XmlAttribute(AttributeName = "name")]
    public string? Name { get; set; }

    [XmlAttribute(AttributeName = "type")]
    public string? Type { get; set; }

}
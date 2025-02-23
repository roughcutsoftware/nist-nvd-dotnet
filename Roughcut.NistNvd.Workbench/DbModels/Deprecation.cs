using System.Xml.Serialization;
using Roughcut.NistNvd.Workbench.Base;

namespace Roughcut.NistNvd.Workbench.DbModels;

[XmlRoot(ElementName = "deprecation", Namespace = "http://scap.nist.gov/schema/cpe-extension/2.3")]
public class Deprecation : EntityBase
{
    [XmlElement(ElementName = "deprecated-by", Namespace = "http://scap.nist.gov/schema/cpe-extension/2.3")]
    public Deprecatedby Deprecatedby { get; set; }

    [XmlAttribute(AttributeName = "date")]
    public string? Date { get; set; }
}
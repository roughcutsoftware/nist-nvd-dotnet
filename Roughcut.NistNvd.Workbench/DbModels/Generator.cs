using System.Xml.Serialization;
using Roughcut.NistNvd.Workbench.Base;

namespace Roughcut.NistNvd.Workbench.DbModels;

[XmlRoot(ElementName = "generator", Namespace = "http://cpe.mitre.org/dictionary/2.0")]
public class Generator : EntityBase
{
    [XmlElement(ElementName = "product_name", Namespace = "http://cpe.mitre.org/dictionary/2.0")]
    public string Product_name { get; set; }
    [XmlElement(ElementName = "product_version", Namespace = "http://cpe.mitre.org/dictionary/2.0")]
    public string Product_version { get; set; }
    [XmlElement(ElementName = "schema_version", Namespace = "http://cpe.mitre.org/dictionary/2.0")]
    public string Schema_version { get; set; }
    [XmlElement(ElementName = "timestamp", Namespace = "http://cpe.mitre.org/dictionary/2.0")]
    public string Timestamp { get; set; }
}
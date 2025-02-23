using System.Xml.Serialization;
using Roughcut.NistNvd.Workbench.Base;
using Roughcut.NistNvd.Workbench.XmlModels;

namespace Roughcut.NistNvd.Workbench.DbModels;

[XmlRoot(ElementName = "references", Namespace = "http://cpe.mitre.org/dictionary/2.0")]
public class References : EntityBase
{
    [XmlElement(ElementName = "reference", Namespace = "http://cpe.mitre.org/dictionary/2.0")]
    public List<Reference> Reference { get; set; }
}
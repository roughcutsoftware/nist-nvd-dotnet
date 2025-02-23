using Roughcut.NistNvd.Workbench.Base;
using System.Xml.Serialization;

namespace Roughcut.NistNvd.Workbench.XmlModels;

[XmlRoot(ElementName = "reference", Namespace = "http://cpe.mitre.org/dictionary/2.0")]
public class Reference : EntityBase
{
    [XmlAttribute(AttributeName = "href")]
    public string Href { get; set; }
    [XmlText]
    public string Text { get; set; }
}
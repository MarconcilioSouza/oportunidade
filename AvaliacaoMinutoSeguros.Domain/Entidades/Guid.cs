using System.Xml.Serialization;

namespace AvaliacaoMinutoSeguros.Domain.Entidades
{
    [XmlRoot(ElementName = "guid")]
    public class Guid
    {
        [XmlAttribute(AttributeName = "isPermaLink")]
        public string IsPermaLink { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
}

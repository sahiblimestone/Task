using System.Xml.Serialization;

namespace Limestone.DAL
{
    [XmlRoot(ElementName = "CurrentBalance")]
	public class CurrentBalance
	{

		[XmlElement(ElementName = "Value")]
		public decimal Value { get; set; }

		[XmlElement(ElementName = "Currency")]
		public string Currency { get; set; }
	}



}

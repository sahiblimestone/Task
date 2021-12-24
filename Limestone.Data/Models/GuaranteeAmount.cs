using System.Xml.Serialization;

namespace Limestone.DAL
{
    [XmlRoot(ElementName = "GuaranteeAmount")]
	public class GuaranteeAmount
	{

		[XmlElement(ElementName = "Value")]
		public decimal Value { get; set; }

		[XmlElement(ElementName = "Currency")]
		public string Currency { get; set; }
	}



}

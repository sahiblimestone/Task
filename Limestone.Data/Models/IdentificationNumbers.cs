using System.Xml.Serialization;

namespace Limestone.DAL
{
    [XmlRoot(ElementName = "IdentificationNumbers")]
	public class IdentificationNumbers
	{

		[XmlElement(ElementName = "NationalID")]
		public string NationalID { get; set; }
	}



}

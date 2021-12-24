using System;
using System.Xml.Serialization;

namespace Limestone.DAL
{
	[Serializable, XmlRoot(ElementName = "Individual", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
	public class Individual
	{

		[XmlElement(ElementName = "CustomerCode")]
		public string CustomerCode { get; set; }

		[XmlElement(ElementName = "FirstName")]
		public string FirstName { get; set; }

		[XmlElement(ElementName = "LastName")]
		public string LastName { get; set; }

		[XmlElement(ElementName = "Gender")]
		public string Gender { get; set; }

		[XmlElement(ElementName = "DateOfBirth")]
		public DateTime DateOfBirth { get; set; }

		[XmlElement(ElementName = "IdentificationNumbers")]
		public IdentificationNumbers IdentificationNumbers { get; set; }
	}



}

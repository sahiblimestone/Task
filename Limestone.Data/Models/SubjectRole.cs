using System;
using System.Xml.Serialization;

namespace Limestone.DAL
{
	[Serializable, XmlRoot(ElementName = "SubjectRole", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
	public class SubjectRole
	{

		[XmlElement(ElementName = "CustomerCode")]
		public string CustomerCode { get; set; }

		[XmlElement(ElementName = "RoleOfCustomer")]
		public string RoleOfCustomer { get; set; }

		[XmlElement(ElementName = "GuaranteeAmount")]
		public GuaranteeAmount GuaranteeAmount { get; set; }
	}



}

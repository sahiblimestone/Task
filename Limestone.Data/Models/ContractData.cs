using System;
using System.Xml.Serialization;

namespace Limestone.DAL
{
	[Serializable, XmlRoot(ElementName = "ContractData", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
	public class ContractData
	{

		[XmlElement(ElementName = "PhaseOfContract")]
		public string PhaseOfContract { get; set; }

		[XmlElement(ElementName = "OriginalAmount")]
		public OriginalAmount OriginalAmount { get; set; }

		[XmlElement(ElementName = "InstallmentAmount")]
		public InstallmentAmount InstallmentAmount { get; set; }

		[XmlElement(ElementName = "CurrentBalance")]
		public CurrentBalance CurrentBalance { get; set; }

		[XmlElement(ElementName = "OverdueBalance")]
		public OverdueBalance OverdueBalance { get; set; }

		[XmlElement(ElementName = "DateOfLastPayment")]
		public DateTime DateOfLastPayment { get; set; }

		[XmlElement(ElementName = "NextPaymentDate")]
		public DateTime NextPaymentDate { get; set; }

		[XmlElement(ElementName = "DateAccountOpened")]
		public DateTime DateAccountOpened { get; set; }

		[XmlElement(ElementName = "RealEndDate")]
		public DateTime RealEndDate { get; set; }
	}



}

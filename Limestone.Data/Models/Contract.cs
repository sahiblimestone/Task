using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Limestone.DAL
{
	[Serializable, XmlRoot(ElementName = "Contract", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
	public class Contract
	{
		[XmlElement(ElementName = "ContractCode")]
		public string ContractCode { get; set; }

		[XmlElement(ElementName = "ContractData")]
		public ContractData ContractData { get; set; }

		[XmlElement(ElementName = "Individual")]
		public List<Individual> Individual { get; set; }

		[XmlElement(ElementName = "SubjectRole")]
		public List<SubjectRole> SubjectRole { get; set; }
	}



}

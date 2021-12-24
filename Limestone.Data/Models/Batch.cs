using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Limestone.DAL
{

    [Serializable, XmlRoot(ElementName = "Batch", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
	public class Batch
	{

		[XmlElement(ElementName = "Contract")]
		public List<Contract> Contract { get; set; }      
    }



}

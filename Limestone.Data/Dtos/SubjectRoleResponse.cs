using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limestone.DAL.Dtos
{
    public class SubjectRoleResponse
    {		
		public string CustomerCode { get; set; }
		public string RoleOfCustomer { get; set; }		
		public decimal GuaranteeAmountValue { get; set; }		
		public string GuaranteeAmountCurrency { get; set; }
	}
}

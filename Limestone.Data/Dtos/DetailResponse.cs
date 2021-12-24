using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limestone.DAL.Dtos
{
    public class DetailResponse
    {
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Gender { get; set; }

		public DateTime DateOfBirth { get; set; }
		public string NationalId { get; set; }
		public string ContractCode { get; set; }
		public List<ContractResponse> ContractResponses { get; set; }
		public List<SubjectRoleResponse> Subjects { get; set; }
	}
}

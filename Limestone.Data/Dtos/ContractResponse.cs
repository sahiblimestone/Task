using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limestone.DAL.Dtos
{
	public class ContractResponse
	{
		public string PhaseOfContract { get; set; }
		public string OriginalAmountCurrency { get; set; }
		public decimal OriginalAmountValue { get; set; }

		public string InstallmentAmountCurrency { get; set; }
		public decimal InstallmentAmountValue { get; set; }

		public string CurrentBalanceCurrency { get; set; }
		public decimal CurrentBalanceValue { get; set; }

		public string OverdueBalanceCurrency { get; set; }
		public decimal OverdueBalanceValue { get; set; }

		public DateTime DateOfLastPayment { get; set; }

		public DateTime NextPaymentDate { get; set; }

		public DateTime DateAccountOpened { get; set; }

		public DateTime RealEndDate { get; set; }
		public string ContractCode { get; set; }
	}
}

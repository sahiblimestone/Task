using Limestone.DAL.Dtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limestone.DAL.Repository
{
    public class ContractRepository : IContractRepository
    {
        private readonly ContractRepository _context;
        private readonly IConfiguration _configuration;
        public ContractRepository( IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public async Task<string> GetIndividualById(string nationalId)
        {
            string result = string.Empty;
            try
            {
              
                var connectionString = _configuration.GetSection("ConnectionStrings:dbConnection").Value;
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand command = new SqlCommand("Select count(*) as Count from Individual where NationalId=@nationalId", conn);
                command.Parameters.AddWithValue("@nationalId", nationalId);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = int.Parse(reader["Count"].ToString()) > 0 ? "single hit" : "no hit";
                    }
                }

                conn.Close();
            }
            catch (Exception)
            {

            }
            return result;
        }

        public async Task<DetailResponse> GetDetailById(string nationalId)
        {
            DetailResponse result = new DetailResponse();
            string contractCode = string.Empty;
            try
            {

                var connectionString = _configuration.GetSection("ConnectionStrings:dbConnection").Value;
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand command = new SqlCommand("Select FirstName,LastName,DateOfBirth,Gender,NationalId,ContractCode  from Individual where NationalId=@nationalId", conn);
                command.Parameters.AddWithValue("@nationalId", nationalId);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result.FirstName = reader["FirstName"].ToString();
                        result.LastName = reader["LastName"].ToString();
                        result.DateOfBirth =Convert.ToDateTime( reader["DateOfBirth"]);
                        result.Gender = reader["Gender"].ToString();
                        result.NationalId = reader["NationalId"].ToString();
                        result.ContractCode= reader["ContractCode"].ToString();
                        contractCode = reader["ContractCode"].ToString();
                    }
                }

                conn.Close();

              
                conn.Open();

                SqlCommand commandContractData = new SqlCommand("Select * from ContractData where ContractCode=@contract", conn);
                commandContractData.Parameters.AddWithValue("@contract", contractCode);
                result.ContractResponses = new List<ContractResponse>();
                using (SqlDataReader reader = commandContractData.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.ContractResponses.Add(new ContractResponse {
                            ContractCode =reader["ContractCode"].ToString(),
                            CurrentBalanceCurrency = reader["CurrentBalanceCurrency"].ToString(),
                            CurrentBalanceValue =Convert.ToDecimal(reader["CurrentBalanceValue"].ToString()),
                            DateAccountOpened=Convert.ToDateTime(reader["DateAccountOpened"].ToString()),
                            DateOfLastPayment =Convert.ToDateTime(reader["DateOfLastPayment"].ToString()),
                            InstallmentAmountCurrency = reader["InstallmentAmountCurrency"].ToString(),
                            InstallmentAmountValue =Convert.ToDecimal(reader["InstallmentAmountValue"].ToString()),
                            NextPaymentDate =Convert.ToDateTime( reader["NextPaymentDate"].ToString()),
                            OriginalAmountCurrency = reader["OriginalAmountCurrency"].ToString(),
                            OriginalAmountValue = Convert.ToDecimal(reader["OriginalAmountValue"].ToString()),
                            OverdueBalanceCurrency = reader["DateOfLastPayment"].ToString(),
                            OverdueBalanceValue = Convert.ToDecimal(reader["OverdueBalanceValue"].ToString()),
                            PhaseOfContract = reader["PhaseOfContract"].ToString(),
                            RealEndDate = Convert.ToDateTime(reader["RealEndDate"].ToString())
                        });
                    }
                }
                conn.Close();
                conn.Open();
                SqlCommand commandSubject = new SqlCommand("Select * from SubjectRole where ContractCode=@contract", conn);
                commandSubject.Parameters.AddWithValue("@contract", contractCode);
                result.Subjects = new List<SubjectRoleResponse>();
                using (SqlDataReader reader = commandSubject.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Subjects.Add(new SubjectRoleResponse
                        {
                            CustomerCode = reader["CustomerCode"].ToString(),
                            RoleOfCustomer= reader["RoleOfCustomer"].ToString(),
                            GuaranteeAmountCurrency= reader["GuaranteeAmountCurrency"].ToString(),
                            GuaranteeAmountValue= string.IsNullOrEmpty(reader["GuaranteeAmountValue"].ToString())?0:Convert.ToDecimal(reader["GuaranteeAmountValue"].ToString())
                        });
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}

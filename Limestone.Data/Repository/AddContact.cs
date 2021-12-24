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
   public class AddContact
    {
        public void InsertContract(List<Contract> contracts)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            foreach (var contract in contracts)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "INSERT into ContractData (PhaseOfContract," +
                                                                        "OriginalAmountCurrency," +
                                                                        "OriginalAmountValue," +
                                                                        "InstallmentAmountCurrency," +
                                                                        "InstallmentAmountValue," +
                                                                        "CurrentBalanceCurrency," +
                                                                        "CurrentBalanceValue," +
                                                                        "OverdueBalanceCurrency," +
                                                                        "OverdueBalanceValue," +
                                                                        "DateOfLastPayment," +
                                                                        "NextPaymentDate," +
                                                                        "DateAccountOpened," +
                                                                        "RealEndDate," +
                                                                        "ContractCode) " +
                                                                        "VALUES (@phaseOfContract," +
                                                                        "@originalAmountCurrency," +
                                                                        "@originalAmountValue," +
                                                                        "@installmentAmountCurrency," +
                                                                        "@installmentAmountValue," +
                                                                        "@currentBalanceCurrency," +
                                                                        "@currentBalanceValue," +
                                                                        "@overdueBalanceCurrency," +
                                                                        "@overdueBalanceValue," +
                                                                        "@dateOfLastPayment," +
                                                                        "@nextPaymentDate," +
                                                                        "@dateAccountOpened," +
                                                                        "@realEndDate," +
                                                                        "@contractCode)";
                        if (contract.ContractData != null)
                        {
                            command.Parameters.AddWithValue("@phaseOfContract", contract?.ContractData?.PhaseOfContract);
                            command.Parameters.AddWithValue("@originalAmountCurrency", contract?.ContractData?.OriginalAmount?.Currency);
                            command.Parameters.AddWithValue("@originalAmountValue", contract?.ContractData?.OriginalAmount?.Value);
                            command.Parameters.AddWithValue("@installmentAmountCurrency", contract?.ContractData?.InstallmentAmount?.Currency);
                            command.Parameters.AddWithValue("@installmentAmountValue", contract?.ContractData?.InstallmentAmount?.Value);
                            command.Parameters.AddWithValue("@currentBalanceCurrency", contract?.ContractData?.CurrentBalance?.Currency);
                            command.Parameters.AddWithValue("@currentBalanceValue", contract?.ContractData?.CurrentBalance?.Value);
                            command.Parameters.AddWithValue("@overdueBalanceCurrency", contract?.ContractData?.OverdueBalance?.Currency);
                            command.Parameters.AddWithValue("@overdueBalanceValue", contract?.ContractData?.OverdueBalance?.Value);
                            command.Parameters.AddWithValue("@dateOfLastPayment", contract?.ContractData?.DateOfLastPayment);
                            command.Parameters.AddWithValue("@nextPaymentDate", contract?.ContractData?.NextPaymentDate);
                            command.Parameters.AddWithValue("@dateAccountOpened", contract?.ContractData?.DateAccountOpened);
                            command.Parameters.AddWithValue("@realEndDate", contract?.ContractData?.RealEndDate);
                            command.Parameters.AddWithValue("@contractCode", contract?.ContractCode);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@phaseOfContract", DBNull.Value);
                            command.Parameters.AddWithValue("@originalAmountCurrency", DBNull.Value);
                            command.Parameters.AddWithValue("@originalAmountValue", DBNull.Value);
                            command.Parameters.AddWithValue("@installmentAmountCurrency", DBNull.Value);
                            command.Parameters.AddWithValue("@installmentAmountValue", DBNull.Value);
                            command.Parameters.AddWithValue("@currentBalanceCurrency", DBNull.Value);
                            command.Parameters.AddWithValue("@currentBalanceValue", DBNull.Value);
                            command.Parameters.AddWithValue("@overdueBalanceCurrency", DBNull.Value);
                            command.Parameters.AddWithValue("@overdueBalanceValue", DBNull.Value);
                            command.Parameters.AddWithValue("@dateOfLastPayment", DBNull.Value);
                            command.Parameters.AddWithValue("@nextPaymentDate", DBNull.Value);
                            command.Parameters.AddWithValue("@dateAccountOpened", DBNull.Value);
                            command.Parameters.AddWithValue("@realEndDate", DBNull.Value);
                            command.Parameters.AddWithValue("@contractCode", contract?.ContractCode);
                        }

                        try
                        {
                            connection.Open();
                            int recordsAffected = command.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            connection.Close();
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
                foreach (var individual in contract.Individual)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand())
                        {

                            command.Connection = connection;
                            command.CommandType = CommandType.Text;
                            command.CommandText = "INSERT into Individual (FirstName," +
                                                                            "LastName," +
                                                                            "Gender," +
                                                                            "DateOfBirth," +
                                                                            "NationalId," +
                                                                            "CustomerCode," +
                                                                            "ContractCode) " +
                                                                            "VALUES (@firstName," +
                                                                            "@lastName," +
                                                                            "@gender," +
                                                                            "@dateOfBirth," +
                                                                            "@nationalId," +
                                                                            "@customerCode," +
                                                                            "@contractCode)";
                            command.Parameters.AddWithValue("@firstName", individual?.FirstName);
                            command.Parameters.AddWithValue("@lastName", individual?.LastName);
                            command.Parameters.AddWithValue("@gender", individual?.Gender);
                            command.Parameters.AddWithValue("@dateOfBirth", individual?.DateOfBirth);
                            command.Parameters.AddWithValue("@nationalId", individual?.IdentificationNumbers.NationalID);
                            command.Parameters.AddWithValue("@customerCode", individual?.CustomerCode);
                            command.Parameters.AddWithValue("@contractCode", contract?.ContractCode);
                            try
                            {
                                connection.Open();
                                int recordsAffected = command.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                connection.Close();
                            }
                            finally
                            {
                                connection.Close();
                            }
                        }
                    }
                }
                foreach (var subjectRole in contract.SubjectRole)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand())
                        {

                            command.Connection = connection;
                            command.CommandType = CommandType.Text;
                            command.CommandText = "INSERT into SubjectRole (RoleOfCustomer," +
                                                                            "GuaranteeAmountCurrency," +
                                                                            "GuaranteeAmountValue," +
                                                                            "CustomerCode," +
                                                                            "ContractCode) " +
                                                                            "VALUES (@roleOfCustomer," +
                                                                            "@guaranteeAmountCurrency," +
                                                                            "@guaranteeAmountValue," +
                                                                            "@customerCode," +
                                                                            "@contractCode)";
                            command.Parameters.AddWithValue("@roleOfCustomer", subjectRole?.RoleOfCustomer);
                            if (subjectRole.GuaranteeAmount != null)
                            {
                                command.Parameters.AddWithValue("@guaranteeAmountCurrency", subjectRole?.GuaranteeAmount?.Currency);
                                command.Parameters.AddWithValue("@guaranteeAmountValue", subjectRole?.GuaranteeAmount?.Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@guaranteeAmountCurrency", DBNull.Value);
                                command.Parameters.AddWithValue("@guaranteeAmountValue", DBNull.Value);
                            }
                            command.Parameters.AddWithValue("@customerCode", subjectRole?.CustomerCode);
                            command.Parameters.AddWithValue("@contractCode", contract?.ContractCode);
                            try
                            {
                                connection.Open();
                                int recordsAffected = command.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                connection.Close();
                            }
                            finally
                            {
                                connection.Close();
                            }
                        }
                    }
                }
            }
        }
    }
}

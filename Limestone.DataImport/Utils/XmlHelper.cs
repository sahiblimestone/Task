using Limestone.DAL;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace Limestone.DALImport.Utils
{
    public class XmlHelper
    {

        internal static Batch XmlParser(string url)
        {
           
            XmlSerializer ser = new XmlSerializer(typeof(Batch));
            WebClient client = new WebClient();
            string data = Encoding.Default.GetString(client.DownloadData(url));
            Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(data));
            var response = (Batch)ser.Deserialize(stream);

            response.Contract.ForEach(x =>
            {
                x.Individual = x.Individual.Where(y => (DateTime.Now.Year - y.DateOfBirth.Year) > 18 && (DateTime.Now.Year - y.DateOfBirth.Year) < 99).ToList();
                x.ContractData = x.ContractData.DateOfLastPayment > x.ContractData.NextPaymentDate ? null
                : (x.ContractData.DateAccountOpened > x.ContractData.DateOfLastPayment ? null : x.ContractData);
                x.SubjectRole = x.SubjectRole.Where(s => x.SubjectRole.Select(s => s.GuaranteeAmount?.Value).Sum() < x.ContractData?.OriginalAmount.Value).ToList();
            });
            return response;
        }

    }
}

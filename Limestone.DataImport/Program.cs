using Limestone.DAL.Repository;
using Limestone.DALImport.Utils;
using System;

namespace Limestone.DALImport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddContact repo = new AddContact();
            string url = "https://creditinfocandidate2k.z16.web.core.windows.net/assets/Sample.xml";
            var response = XmlHelper.XmlParser(url);
            repo.InsertContract(response.Contract);
            Console.ReadKey();
        }

      
    }
}

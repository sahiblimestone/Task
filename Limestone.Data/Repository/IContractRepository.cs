using Limestone.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limestone.DAL.Repository
{
    public interface IContractRepository : IDisposable
    {
        Task<string> GetIndividualById(string nationalId);
        Task<DetailResponse> GetDetailById(string nationalId);
    }
}

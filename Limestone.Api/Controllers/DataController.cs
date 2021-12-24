using Limestone.DAL;
using Limestone.DAL.Dtos;
using Limestone.DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Limestone.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        IContractRepository _contractService;

        public DataController(IContractRepository service)
        {
            _contractService = service;
        }
        [HttpGet, Route("search")]
        public async Task<ActionResult<string>> Search(string nationalId)
        {
            var getIndividual = await _contractService.GetIndividualById(nationalId);
            return Ok(getIndividual);
        }
        [HttpGet, Route("getDetail")]
        public async Task<ActionResult<DetailResponse>> Detail(string nationalId)
        {
            var detail = await _contractService.GetDetailById(nationalId);
            return Ok(detail);
        }
    }
}

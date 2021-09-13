using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WNTS_V1._0._2.Interface;
using WNTS_V1._0._2.Models;

namespace WNTS_V1._0._2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GasOperationController : ControllerBase
    {
        private readonly IGasOperation _dataAccessProvider;

        public GasOperationController(IGasOperation dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IEnumerable<PL_OPERATION> Get()
        {
            return _dataAccessProvider.GetGasOperation();
        }

        [HttpGet("{startdate}/{enddate}")]
        public List<PL_OPERATION> FilterDate(string startdate, string enddate)
        {
            var a = _dataAccessProvider.GetGasOperationByDate(startdate, enddate);
            return a;
        }
    }
}

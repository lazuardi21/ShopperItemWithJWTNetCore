using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
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
    
    public class GasComponentController : ControllerBase
    {
        private readonly IGasComponent _dataAccessProvider;

        public GasComponentController(IGasComponent dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        [Authorize]
       
        public IEnumerable<PL_GAS_COMPONENT> Get()
        {
            return _dataAccessProvider.GetGasComponent();
        }

        [HttpGet("{id}")]
        public IEnumerable<PL_GAS_COMPONENT> Filter(int id)
        {
            return _dataAccessProvider.GetGasComponentById(id);
        }

        [HttpGet("{startdate}/{enddate}")]
        public List<PL_GAS_COMPONENT> FilterDate(string startdate, string enddate)
        {
            var a = _dataAccessProvider.GetGasComponentByDate(startdate, enddate);
            return a;
        }

        [HttpGet("{id}/{startdate}/{enddate}")]
        public List<PL_GAS_COMPONENT> FilterDateId(int id, string startdate, string enddate)
        {
            var a = _dataAccessProvider.GetGasComponentByDateId(id, startdate, enddate);
            return a;
        }


    }
}

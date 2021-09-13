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
    public class GasCoOpController : ControllerBase
    {
        private readonly IGasCoOp _dataAccessProvider;
        public GasCoOpController(IGasCoOp dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet("all/{startdate}/{enddate}")]
        public List<PV_CoOp> FilterDate(string startdate, string enddate)
        {
            var a = _dataAccessProvider.GetGasCoOpByDate( startdate, enddate);
            return a;
        }

        [HttpGet("last/{startdate}/{enddate}")]
        public List<PV_CoOp> FilterlastDate( string startdate, string enddate)
        {
            var a = _dataAccessProvider.GetlastGasCoOpByDate( startdate, enddate);
            return a;
        }

        [HttpGet("all/{id}/{startdate}/{enddate}")]
        public List<PV_CoOp> FilterDateId(int id, string startdate, string enddate)
        {
            var a = _dataAccessProvider.GetGasCoOpByDateId(id, startdate, enddate);
            return a;
        }

        [HttpGet("allPivot/{id}/{startdate}/{enddate}")]
        public List<Pivot_CoOp> FilterDateIdPivot(int id, string startdate, string enddate)
        {
            var a = _dataAccessProvider.GetGasCoOpByDateIdPivot(id, startdate, enddate);
            return a;
        }

        [HttpGet("allId")]
        public List<PV_CoOp> GetAllId()
        {
            var a = _dataAccessProvider.GetAllId();
            return a;
        }

        [HttpGet("last")]
        public ActionResult<List<PV_CoOp>> LastData(Filter data)
        {
            var a = _dataAccessProvider.GetlastGasCoOpByDate(data.START_DATE, data.END_DATE);
            return a;
        }
        [HttpGet("all")]
        public ActionResult<List<PV_CoOp>> AllData(Filter data)
        {
            if (data.ASSET_ID == 0)
            {
                var a = _dataAccessProvider.GetGasCoOpByDate(data.START_DATE, data.END_DATE);
                return a;
            }
            else {
                var a = _dataAccessProvider.GetGasCoOpByDateId(data.ASSET_ID, data.START_DATE, data.END_DATE);
                return a;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WNTS_V1._0._2.Models;

namespace WNTS_V1._0._2.Interface
{
    public interface IGasCoOp
    {
        List<PV_CoOp> GetGasCoOpByDate(string startdate, string enddate);
        List<PV_CoOp> GetlastGasCoOpByDate(string startdate, string enddate);
        List<PV_CoOp> GetGasCoOpByDateId(int id, string startdate, string enddate);
        List<Pivot_CoOp> GetGasCoOpByDateIdPivot(int id, string startdate, string enddate);
        List<PV_CoOp> GetAllId();

    }
}

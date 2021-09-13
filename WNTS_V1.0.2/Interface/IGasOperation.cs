using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WNTS_V1._0._2.Models;

namespace WNTS_V1._0._2.Interface
{
    public interface IGasOperation
    {
        IEnumerable<PL_OPERATION> GetGasOperation();

        List<PL_OPERATION> GetGasOperationByDate(string startdate, string enddate);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WNTS_V1._0._2.Models;
//using System.Collections.Generic;

namespace WNTS_V1._0._2.Interface
{
    public interface IGasComponent
    {
        IEnumerable<PL_GAS_COMPONENT> GetGasComponent();
        IEnumerable<PL_GAS_COMPONENT> GetGasComponentById(int eid);
        List<PL_GAS_COMPONENT> GetGasComponentByDate(string startdate, string enddate);
        List<PL_GAS_COMPONENT> GetGasComponentByDateId(int id, string startdate, string enddate);


        //void AddGasComponent(PL_GAS_COMPONENT GasComponent);
        //void EditGasComponent(PL_GAS_COMPONENT GasComponent);
        //void DeleteGasComponent(PL_GAS_COMPONENT GasComponent);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WNTS_V1._0._2.Models
{
    public class PV_CoOp
    {
        public int ASSET_ID { get; set; }

        public DateTime DATE_STAMP { get; set; }
        public float C1 { get; set; }
        public float C2 { get; set; }
        public float C3 { get; set; }
        public float IC4 { get; set; }
        public float NC4 { get; set; }
        public float IC5 { get; set; }
        public float NC5 { get; set; }
        public float C6 { get; set; }
        public float C7 { get; set; }
        public float C8 { get; set; }
        public float C9 { get; set; }
        public float N2 { get; set; }
        public float CO2 { get; set; }
        public float H2O { get; set; }
        public float HCDP { get; set; } 
        public float CALC_HCDP { get; set; }
        public float GHV { get; set; }
        public float PRESSURE { get; set; }
        public float TEMPERATURE { get; set; }
        public float MOISTURE { get; set; }
        public float ENERGY_RATE { get; set; }
        public float VOLUME_RATE { get; set; }
        public float INLET_PRESSURE { get; set; }
        public float INLET_TEMPERATURE { get; set; }
        public float FUEL_VOLUME_RATE { get; set; }
        public float FUEL_ENERGY_RATE { get; set; }
        public string NAME { get; set; }
    }
}

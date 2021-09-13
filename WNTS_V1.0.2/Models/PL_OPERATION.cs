using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WNTS_V1._0._2.Models
{
    public class PL_OPERATION
    {
        public int ASSET_ID { get; set; }
        public DateTime DATE_STAMP { get; set; }
        public float PRESSURE { get; set; }
        public float TEMPERATURE{ get; set; }
        public float MOISTURE{ get; set; }
        public float ENERGY_RATE { get; set; }
        public float VOLUME_RATE{ get; set; }
        public float INLET_PRESSURE { get; set; }
        public float INLET_TEMPERATURE { get; set; }
        public float FUEL_VOLUME_RATE{ get; set; }
        public float FUEL_ENERGY_RATE { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WNTS_V1._0._2.Models
{
    public class SHOPPING
    {
        [Required]
        public int id { get; set; }

        public string name { get; set; }
        public string createddate { get; set; }
       
    }
}

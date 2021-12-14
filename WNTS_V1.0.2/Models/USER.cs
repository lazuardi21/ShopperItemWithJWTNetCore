using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WNTS_V1._0._2.Models
{
    public class USER
    {
        [Required]
        public int id { get; set; }

        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string postcode { get; set; }
        public string name { get; set; }
        public string address { get; set; }

    }
}

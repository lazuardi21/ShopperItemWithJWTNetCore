using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WNTS_V1._0._2.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string USER_NAME { get; set; }

        [Required]
        public string PASSWORD { get; set; }
    }
}

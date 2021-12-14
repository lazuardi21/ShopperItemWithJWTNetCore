using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WNTS_V1._0._2.Models
{
    public class AuthenticateResponse
    {
        public int USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
        public string TOKEN { get; set; }


        public AuthenticateResponse(USER user, string token)
        {
            USER_ID = user.id;
            USER_NAME = user.username;
            TOKEN = token;
        }
    }
}

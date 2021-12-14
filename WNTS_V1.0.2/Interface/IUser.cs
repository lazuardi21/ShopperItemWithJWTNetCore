using System.Collections.Generic;
using WNTS_V1._0._2.Models;

namespace WNTS_V1._0._2.Interface
{
    public interface IUser
    {
        List<USER> Authenticate(string email, string PASSWORD);
        IEnumerable<USER> GetAll();
        USER GetByName(string email);
        List<USER> Register(string user_name, string PASSWORD_ENC, string email, string phone, string country, string city, string postcode, string name, string address);


    }

    
}

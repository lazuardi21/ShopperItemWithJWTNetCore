using System.Collections.Generic;
using WNTS_V1._0._2.Models;

namespace WNTS_V1._0._2.Interface
{
    public interface IUser
    {
        List<PL_USER> Authenticate(string USER_NAME, string PASSWORD);
        IEnumerable<PL_USER> GetAll();
        PL_USER GetByName(string name);
        void Register(string USER_NAME,  string PASSWORD);


    }

    
}

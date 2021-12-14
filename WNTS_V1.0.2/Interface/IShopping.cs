using System;
using System.Collections.Generic;
using WNTS_V1._0._2.Models;

namespace WNTS_V1._0._2.Interface
{
    public interface IShopping
    {
        List<SHOPPING> Authenticate(string email, string PASSWORD);
        IEnumerable<SHOPPING> GetAll();
        SHOPPING GetByName(string email);
        List<SHOPPING> GetById(int Id);
        List<SHOPPING> Add(string name, string createddate);


    }

    
}

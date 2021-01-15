using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GaregeApi.Modelos;

namespace GaregeApi.InterfaceDTOs
{
    interface ISecurity
    {        
        public LoginModel Identificar(string email, string pwd);

        public string InsertToken();
    }
}

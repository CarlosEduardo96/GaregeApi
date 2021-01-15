using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GaregeApi.Modelos;
using GaregeApi.Configuracion;
using GaregeApi.InterfaceDTOs;

namespace GaregeApi.DTOs
{
    /// <summary>
    /// Interactua con la tabla de login en la base de datos
    /// </summary>
    public class LoginDTO : Conections, QueryDTO<LoginModel>
    {
        public LoginModel Delete(int id)
        {
            throw new NotImplementedException();
        }

        public LoginModel Find(LoginModel type)
        {
            throw new NotImplementedException();
        }

        public LoginModel Insert(LoginModel type)
        {
            //CURDATE()
            throw new NotImplementedException();
        }

        public LoginModel SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public LoginModel SelectByName(LoginModel type)
        {
           throw new NotImplementedException();
        }

        public LoginModel Update(LoginModel type)
        {
            throw new NotImplementedException();
        }
    }
}

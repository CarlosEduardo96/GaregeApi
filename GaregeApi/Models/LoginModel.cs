using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GaregeApi.Modelos
{
    public class LoginModel
    {

        public int id { get; set; }
        [Required(ErrorMessage = "Nombre se usuario requerido")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Correo requerido")]
        public string email { get; set; }

        [Required(ErrorMessage = "Contraseña requerida")]
        public string pwd { get; set; }

        [Required(ErrorMessage = "Tipo de usuario requerido")]
        public string tipo { get; set; }


        public DateTime last_session {get; set;}
        public DateTime firts_session { get; set; }
        public string _token { get; set; }
    }
}

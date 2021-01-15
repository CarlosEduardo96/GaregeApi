using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GaregeApi.Modelos
{
    public class AutentifyModel
    {
        [Required(ErrorMessage = "Nombre de usuario requerido")]
        public string email { get; set; }

        public string pwd { get; set; }
    }
}

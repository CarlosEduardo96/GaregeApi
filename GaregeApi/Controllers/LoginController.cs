using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GaregeApi.Modelos;
using GaregeApi.Configuracion;
using GaregeApi.DTOs;

namespace GaregeApi.Controllers
{
    /// <summary>
    /// Realiza peticiones en la tabla login
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost("/Layout")]
        public IActionResult Login([FromBody] AutentifyModel login) {
            Autentificar auth = new Autentificar();
            PaqueteTCP pack = new PaqueteTCP();

            LoginModel user = auth.Identificar(login.email,login.pwd);

            if (user != null) {
                List<LoginModel> data = new List<LoginModel>();
                data.Add(user);
                pack.StatusCode = 200;
                pack.Status="Success";
                pack.Mensage = "Autentificado";
                pack.Data = data.ToArray();
                return Ok(pack);
            }
            else {
                pack.StatusCode = 400;
                pack.Status = "Error al autentificar";
                pack.Mensage = "Usuario y contraseña no validos";
                return BadRequest();
            }
            
        }
    }
}

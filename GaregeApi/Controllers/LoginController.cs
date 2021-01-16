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
        /// <summary>
        /// Inicia sesion en el sistema
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("/Layout")]
        public IActionResult Login([FromBody] AutentifyForm login) {
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

        /// <summary>
        /// Agrega un nuevo usuario
        /// </summary>
        /// <returns></returns>
        [HttpPut("create")]
        public IActionResult Create([FromBody] LoginModel user) {
            LoginDTO query = new LoginDTO();
            PaqueteTCP pack = new PaqueteTCP();
            LoginModel insert = query.Insert(user);
            if (insert != null)
            {
                pack.StatusCode = 200;
                pack.Status = "Success";
                pack.Mensage = "Registro Agregado Correctamenete";

                List<LoginModel> data = new List<LoginModel>();
                data.Add(insert);

                pack.Data = data.ToArray();

                return Ok(pack);
            }
            else {
                pack.StatusCode = 400;
                pack.Status = "Error";
                pack.Mensage = "Error al crear el usuario es posible que el correo ya este resgistrado";
                return BadRequest(pack);
            }
        }

        [HttpPost("edit")]
        public IActionResult Update([FromBody] LoginModel user) {
            LoginDTO query = new LoginDTO();
            PaqueteTCP pack = new PaqueteTCP();

            LoginModel upgrade = query.Update(user);

            if (upgrade != null)
            {
                pack.StatusCode = 200;
                pack.Status = "Success";
                pack.Mensage = "Usuario actualizado";

                List<LoginModel> data = new List<LoginModel>();
                data.Add(upgrade);

                pack.Data = data.ToArray();

                return Ok(pack);
            }
            else {
                pack.StatusCode = 400;
                pack.Status = "Error";
                pack.Mensage = "Error al actualizar los datos";
                return BadRequest(pack);

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaregeApi.DTOs
{
    /// <summary>
    /// Envia datos al cliente mediante ApiRest usando 
    /// los codigos de respuestas HTTP/HTTPS
    /// </summary>
    public class PaqueteTCP
    {
        /// <summary>
        /// Verifica el codigo de estado HTTP/HTTPS
        /// <para>Verifica el tipo respuesta mas informacion:
        /// </para>
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// Respuesta de la peticion HTTP/HTTPS
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Mensaje del estado
        /// <para>Puedes enviar un mensaje personalizazo</para>
        /// </summary>
        public string Mensage { get; set; }

        /// <summary>
        /// Envia datos al cliente mediante protocolo HTTP/HTTPS
        /// <para>Esta envia datos al cliente de tipo <see cref="Array"/> para 
        /// enviar los datos por el protocolo TCP/IP</para>
        /// </summary>
        public Array Data { get; set; }
    }
}

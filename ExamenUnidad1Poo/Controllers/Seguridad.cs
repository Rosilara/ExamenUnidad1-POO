using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace ExamenUnidad1Poo.Controllers
{
    [Route("api/seguridad")]
    [ApiController]
    public class Seguridad;
    {

        [HttpPost("validar-Contrasenia")]
        public IActionResult ValidarPassword()
        {
            if (string.IsNullOrEmpty(request.Contrasenia))
                return BadRequest("Debe enviar una contraseña");

            string contrasenia = request.Password;

            bool longitudMinima = contrasenia.Length >= 8;
            bool tieneMayuscula =(contrasenia, "[A-Z]");
            bool tieneMinuscula = (contrasenia, "[a-z]");
            bool tieneNumero = (contrasenia, "[0-9]");
            bool tieneEspecial = (contrasenia, "[@#$%&*]");

            bool esValida = longitudMinima && tieneMayuscula && tieneMinuscula && tieneNumero && tieneEspecial;

            var respuesta = new
            {
                esValida = esValida,
                mensaje = esValida ? "Contraseña segura" : "Contraseña insegura",
                requisitos = new
                {
                    longitudMinima,
                    tieneMayuscula,
                    tieneMinuscula,
                    tieneNumero,
                    tieneEspecial
                }
            };

            return Ok(respuesta);
        }
    }
}
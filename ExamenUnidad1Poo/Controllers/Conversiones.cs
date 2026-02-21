using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace ExamenUnidad1Poo.Controllers
{
    [Route("api/conversiones")]
    [ApiController]
    public class Conversiones;


        [HttpGet("temperatura?valor={valor}&de={escalaOrigen}&a={escalaDestino}")]
        public IActionResult Convertir(double Valor, string De, string a)
    {
        de = de.ToUpper();
        a = a.ToUpper();

        if ((De == "C" || De == "F" || De == "K") &&
            (a == "C" || a == "F" || a == "K"))
        {
            double resultado = Valor;

            
            if (De == "F") resultado = (Valor) - 32) * 5 / 9;
            else if (De == "K") resultado = Valor - 273.15;

        
            if (a == "F") resultado = (resultado * 9 / 5) + 32;
            else if (a == "K") resultado = resultado + 273.15;

            var respuesta = new
            {
                ValorOriginal = Valor,
                escalaOriginal = NombreEscala(de),
                ValorValorConvertido = Math.Round(resultado, 2),
                escalaDestino = NombreEscala(a)
            };

            return Ok(respuesta);
        }

        return BadRequest("Escalas válidas: C, F, K");
    }

    private string NombreEscala(string e)
        {
            return e switch
            {
                "C" => "Celsius",
                "F" => "Fahrenheit",
                "K" => "Kelvin",
                _ => ""
            };
        }
    }
}
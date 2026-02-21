using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenUnidad1Poo.Controllers
{
    [Route("api/salud")]
    [ApiController]
    public class Salud
    {


        [HttpGet("imc?peso={peso}&altura={altura}")]

        public IActionResult CalcularIMC(double peso, double altura)
        {
            
            if (peso <= 0 || altura <= 0)
            {
                return BadRequest("PESO Y ALTURA DEBEN DER MAYORES A 0");
            }

            
            double imc = peso / (altura * altura);

            
            string clasificacion;

            if (imc < 18.5)
                clasificacion = "Bajo peso";
            else if (imc < 25)
                clasificacion = "Normal";
            else if (imc < 30)
                clasificacion = "Sobrepeso";
            else
                clasificacion = "Obesidad";

    


        
            var resultado = new
            {
                peso = peso,
                altura = altura,
                imc = imc,
                clasificacion = clasificacion
            };

            return Ok(resultado);
        }
    }
}
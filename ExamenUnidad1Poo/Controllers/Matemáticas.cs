using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenUnidad1Poo.Controllers
{
    [Route("api/matematicas")]
    [ApiController]
    public class Matemáticas 
    

        [HttpGet("tabla/{numero}?hasta={limite}")]

        public IActionResult TablaMultiplicar(string numero , int numero, int hasta = 10)
        {
            if (hasta <= 0)
                return BadRequest("ES MAYOR A 0 EL LIMITE");

            var tabla = new List<string>();

            for (int i = hasta; i >= 1; i--)
            {
                tabla.Add("numero +  x  i = (numero * i");
            }

            var resultado = new
            {
                numero,
                hasta,
                tabla,
            };

            return Ok(resultado);
        }

        
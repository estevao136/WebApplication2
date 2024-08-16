using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/pessoa")]
    public class PessoaController : ControllerBase
    {

        [HttpPost("calcular-e-consultar-imc")]
        public IActionResult CalcularEConsultarIMC([FromBody] pclasse pclasse)
        {
            if (pclasse.Altura <= 0 || pclasse.Peso <= 0)
            {
                return BadRequest("Peso e altura devem ser maiores que zero.");
            }

            double imc = pclasse.Peso / (pclasse.Altura * pclasse.Altura);
            string descricao = ObterDescricaoIMC(imc);

            return Ok(new
            {
                Nome = pclasse.Nome,
                Peso = pclasse.Peso,
                Altura = pclasse.Altura,
                IMC = imc,
                Descricao = descricao
            });
        }

        private string ObterDescricaoIMC(double imc)
        {
            if (imc < 16)
            {
                return "Magreza grave";
            }
            else if (imc >= 16 && imc < 16.9)
            {
                return "Magreza moderada";
            }
            else if (imc >= 17 && imc < 18.4)
            {
                return "Magreza leve";
            }
            else if (imc >= 18.5 && imc < 24.9)
            {
                return "Saudável";
            }
            else if (imc >= 25 && imc < 29.9)
            {
                return "Sobrepeso";
            }
            else if (imc >= 30 && imc < 34.9)
            {
                return "Obesidade grau I";
            }
            else if (imc >= 35 && imc < 39.9)
            {
                return "Obesidade grau II";
            }
            else
            {
                return "Obesidade grau III";
            }
        }
    }
}
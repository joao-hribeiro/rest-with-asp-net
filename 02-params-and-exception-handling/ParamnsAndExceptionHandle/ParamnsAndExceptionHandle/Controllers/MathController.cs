using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace ParamnsAndExceptionHandle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        [HttpGet("sum/{a}/{b}")]
        public IActionResult Get(string a, string b)
        {
            if (isNumeric(a) && isNumeric(b))
            {
                var sum = ConvertToDecimal(a) + ConvertToDecimal(b);
                return Ok(sum);
            }
            return BadRequest("Invalid Input! Must be a number");
        }

        private decimal ConvertToDecimal(string value)
        {
            decimal decimalValue;
            // Se ele conseguir converter o valor para decimal, ele retorna o valor convertido, caso contrário retorna 0
            if (decimal.TryParse(
                value,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimalValue
            )) return decimalValue;
            return 0;
        }

        private bool isNumeric(string value)
        {
            decimal decimalValue;
            bool isNumber = decimal.TryParse( // Retorna TRUE se consegue fazer a conversão, caso contrário retorna FALSE
                value, 
                System.Globalization.NumberStyles.Any, //Aceita todos os estilos de números
                System.Globalization.NumberFormatInfo.InvariantInfo, // Usa a cultura invariante para evitar problemas com vírgulas e pontos
                out decimalValue
            ); 
            return isNumber;
        }
    }
}

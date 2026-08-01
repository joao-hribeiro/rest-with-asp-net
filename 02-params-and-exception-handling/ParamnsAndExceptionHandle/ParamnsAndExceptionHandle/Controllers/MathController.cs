using Microsoft.AspNetCore.Mvc;
using ParamnsAndExceptionHandle.Services;
using ParamnsAndExceptionHandle.Utils;
using System.Diagnostics.CodeAnalysis;

namespace ParamnsAndExceptionHandle.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class MathController : ControllerBase
    {
        // Injeção de dependência
        private readonly MathService _service;
        public MathController(MathService service)
        {
            _service = service;
        }

        [HttpGet("sum/{a}/{b}")]
        public IActionResult Sum(string a, string b)
        {
            if (NumberHelper.isNumeric(a) && NumberHelper.isNumeric(b))
            {
                var sum = _service.Sum(NumberHelper.ConvertToDecimal(a), NumberHelper.ConvertToDecimal(b));
                return Ok(sum);
            }
            return BadRequest("Invalid Input! Must be a number");
        }

        [HttpGet("subtraction/{a}/{b}")]
        public IActionResult Subtraction(string a, string b)
        {
            if(NumberHelper.isNumeric(a) && NumberHelper.isNumeric(b)) {

                var sub = _service.Sub(NumberHelper.ConvertToDecimal(a), NumberHelper.ConvertToDecimal(b));
                return Ok(sub);
            }
            return BadRequest("Must be a number");
        }

        [HttpGet("multiplication/{a}/{b}")]
        public IActionResult Multiplication(string a, string b)
        {
            if(NumberHelper.isNumeric(a) && NumberHelper.isNumeric(b))
            {
                var mult = _service.Multiply(NumberHelper.ConvertToDecimal(a), NumberHelper.ConvertToDecimal(b));
                return Ok(mult);
            }
            return BadRequest("Must be a number");
        }

        [HttpGet("division/{a}/{b}")]
        public IActionResult Division(string a, string b)
        {
            if(NumberHelper.ConvertToDecimal(b) == 0)
            {
                return BadRequest("The denominator can't be zero!");
            }
            if (NumberHelper.isNumeric(a) && NumberHelper.isNumeric(b))
            {
                var div = _service.Div(NumberHelper.ConvertToDecimal(a), NumberHelper.ConvertToDecimal(b));
                return Ok(div);
            }
            return Ok("Must be a number");
        }

        [HttpGet("pow/{a}/{b}")]
        public IActionResult Pow(string a, string b)
        { 
            if (NumberHelper.isNumeric(a) && NumberHelper.isNumeric(b))
            {
                var pow = _service.Pow(NumberHelper.ConvertToDecimal(a), NumberHelper.ConvertToDecimal(b));
                return Ok(pow);
            }
            return Ok("Must be a number");
        }

        [HttpGet("root/{a}/{b}")]
        public IActionResult Root(string a, string b)
        {
            if (NumberHelper.ConvertToDecimal(b) == 0)
            {
                return BadRequest("Can't be zero!");
            }
            if (NumberHelper.isNumeric(a) && NumberHelper.isNumeric(b))
            {
                var root = _service.Root(NumberHelper.ConvertToDecimal(a), NumberHelper.ConvertToDecimal(b));
                return Ok(root);
            }
            return Ok("Must be a number");
        }

        [HttpGet("mean/{a}/{b}")]
        public IActionResult Mean(string a, string b)
        {
            if (NumberHelper.isNumeric(a) && NumberHelper.isNumeric(b))
            {
                var mean = _service.Mean(NumberHelper.ConvertToDecimal(a), NumberHelper.ConvertToDecimal(b));
                return Ok(mean);
            }
            return Ok("Must be a number");
        }
    }
}

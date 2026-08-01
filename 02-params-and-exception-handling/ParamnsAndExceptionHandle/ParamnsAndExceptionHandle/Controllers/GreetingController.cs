using Microsoft.AspNetCore.Mvc;
using ParamnsAndExceptionHandle.Model;

namespace ParamnsAndExceptionHandle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController : ControllerBase
    {
        private static long _counter = 0;
        private static readonly string _template = "Hello, {0}!";

        [HttpGet]
        public Greeting Get([FromQuery] string name = "World", [FromQuery] int id = 0) 
        {
            var content = string.Format(_template, name);
            return new Greeting(id, content);
        }
    }
}

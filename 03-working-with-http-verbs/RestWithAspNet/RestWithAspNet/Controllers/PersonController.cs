using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithAspNet.Services;
using RestWithAspNet.Services.Impl;
using RestWithAspNet.Model;

namespace RestWithAspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonServices _personService;
        public PersonController(IPersonServices personService)
        {
            _personService = personService;
        }
         
        [HttpGet]
        public IActionResult Get()
        {
            var people = _personService.FindAll();
            if (people == null) return NotFound();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            var p = _personService.Create(person);
            if (p == null) return NotFound();
            return Ok(person);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            var p = _personService.Update(person);
            if (p == null) return NotFound();
            return Ok(person);
        }

        [HttpDelete("{a}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}

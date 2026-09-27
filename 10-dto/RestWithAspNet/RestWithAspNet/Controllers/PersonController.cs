using Microsoft.AspNetCore.Mvc;
using RestWithAspNet.Services;
using RestWithAspNet.Data.DTO;

namespace RestWithAspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonServices _personService;
        private readonly ILogger _logger;
        public PersonController(IPersonServices personService, ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
        }
         
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Fetching all people");
            var people = _personService.FindAll();
            if (people == null) return NotFound();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Fetching person with ID {id}", id);
            var person = _personService.FindById(id);
            if (person == null) {
                _logger.LogError("Can't find person with ID {id}", id);
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonDTO person)
        {
            _logger.LogInformation("Creating new person: {firstName}", person.FirstName);
            var p = _personService.Create(person);
            if (p == null)
            {
                _logger.LogError("Failed to create person with name {firsName}", person.FirstName);
                return BadRequest();
            }
            return Ok(p);
        }

        [HttpPut]
        public IActionResult Put([FromBody] PersonDTO person)
        {
            _logger.LogInformation("Updating person with ID {id}", person.Id);
            var p = _personService.Update(person);
            if (p == null)
            {
                _logger.LogError("Failed to update person with ID {id}", person.Id);
                return NotFound();
            }
            _logger.LogDebug("Person updated sucessfully: {firstName}", person.FirstName);
            return Ok(p);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting person with ID {id}", id);
            _personService.Delete(id);
            _logger.LogDebug("Person with ID {id} deleted succesfully", id);
            return NoContent();
        }
    }
}

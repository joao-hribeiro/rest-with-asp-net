using Microsoft.AspNetCore.Mvc;
using RestWithAspNet.Services;
using RestWithAspNet.Model;

namespace RestWithAspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        //Injecao de dependencias
        private readonly IBookServices _bookServices;
        private readonly ILogger _logger;
        public BookController(IBookServices bookServices, ILogger<BookController> logger)
        {
            _bookServices = bookServices;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Fetching all books");
            var books = _bookServices.FindAll();
            if(books == null) return NotFound();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Fetching book with ID: {id}", id);
            var book = _bookServices.FindById(id);
            if (book == null)
            {
                _logger.LogError("Can't find book ID: {id}", id);
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            _logger.LogInformation("Creating book {title}", book.Title);
            var b = _bookServices.Create(book);
            if (b == null)
            {
                _logger.LogError("Can't create book: {title}", book.Title);
                return BadRequest();
            }
            return Ok(book);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            _logger.LogInformation("Updating book {title}", book.Title);
            var b = _bookServices.Update(book);
            if (b == null)
            {
                _logger.LogError("Can't update book: {title}", book.Title);
                return BadRequest();
            }
            _logger.LogDebug("Book updated sucessfully: {title}", book.Title);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting book with ID {id}", id);
            _bookServices.Delete(id);
            _logger.LogDebug("Book with ID {id} deleted succesfully", id);
            return NoContent();
        }

    }
}

using RestWithAspNet.Model;
using RestWithAspNet.Repositories;

namespace RestWithAspNet.Services.Impl
{
    public class BookServicesImpl : IBookServices
    {
        private readonly IRepository<Book> _bookRepository;
        public BookServicesImpl(IRepository<Book> repository) 
        { 
            _bookRepository = repository;
        }
        public List<Book> FindAll()
        {
            return _bookRepository.FindAll();
        }

        public Book FindById(long id)
        {
            return _bookRepository.FindById(id);
        }

        public Book Create(Book book)
        {
            return _bookRepository.Create(book);
        }


        public Book Update(Book book)
        {
            return _bookRepository.Update(book);
        }
        public void Delete(long id)
        {
            _bookRepository.Delete(id);
        }
    }
}

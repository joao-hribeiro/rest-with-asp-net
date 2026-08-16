using RestWithAspNet.Model;
using RestWithAspNet.Model.Context;

namespace RestWithAspNet.Repositories.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly PGSQLContext _context;
        public BookRepository(PGSQLContext context)
        {
            _context = context;
        }
        public Book Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }
        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(long id)
        {
            return _context.Books.Find(id);
        }

        public Book Update(Book book)
        {
            var existingPerson = _context.Books.Find(book.Id);
            if (existingPerson == null) return null;

            _context.Entry(existingPerson).CurrentValues.SetValues(book);
            _context.SaveChanges();
            return book;

        }

        public void Delete(long id)
        {
            var existingPerson = _context.Books.Find(id);
            if (existingPerson == null) return;

            _context.Remove(existingPerson);
            _context.SaveChanges();
        }
    }
}

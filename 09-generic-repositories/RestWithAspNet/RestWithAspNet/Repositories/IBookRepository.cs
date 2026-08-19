using RestWithAspNet.Model;

namespace RestWithAspNet.Repositories
{
    public interface IBookRepository
    {
        Book Create(Book book);
        List<Book> FindAll();
        Book FindById(long id);
        Book Update(Book book);
        void Delete(long id);

    }
}

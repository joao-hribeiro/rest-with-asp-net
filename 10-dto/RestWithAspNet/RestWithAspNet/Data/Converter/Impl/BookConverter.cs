using RestWithAspNet.Data.Converter.Contract;
using RestWithAspNet.Data.DTO;
using RestWithAspNet.Model;

namespace RestWithAspNet.Data.Converter.Impl
{
    public class BookConverter : IParser<BookDTO, Book>, IParser<Book, BookDTO>
    {
        public Book Parse(BookDTO origin)
        {
            if(origin == null) return null;
            return new Book
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
            };
        }

        public List<Book> ParseList(List<BookDTO> origin)
        {
            if( origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public BookDTO Parse(Book origin)
        {
            if (origin == null) return null;
            return new BookDTO
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
            };
        }

        public List<BookDTO> ParseList(List<Book> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}

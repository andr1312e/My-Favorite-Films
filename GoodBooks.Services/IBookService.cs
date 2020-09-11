using System.Collections.Generic;

namespace GoodBooks.Services
{
    public interface IBookService
    {
        public void AddBook(Book Book);
        public void DeleteBook(int bookId);
        public List<Book> GetAllBooks();
        public Book GetBook(int bookId);
    }
}
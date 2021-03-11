using Books.Models;
using System.Collections.Generic;

namespace Books.Services
{
    internal interface IBooksServices
    {
        List<BookModel> GetAllBooks();

        List<BookModel> FoundBooks(string searchByTilte, string searchByAuthor, string searchByGenre);

        int AddBook(BookModel bookModel);

        BookModel DetailBook(int idBook);

        int UpdateBook(BookModel bookModel);

        int DeleteBook(BookModel bookModel);
    }
}
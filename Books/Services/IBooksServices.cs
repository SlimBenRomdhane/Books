using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Services
{
    interface IBooksServices
    {
        List<BookModel> GetAllBooks();
        List<BookModel> FoundBooks(string searchParam);
        int AddBook(BookModel bookModel);
        BookModel DetailBook(int idBook);
        int UpdateBook(BookModel bookModel);
        int DeleteBook(BookModel bookModel);
    }
}

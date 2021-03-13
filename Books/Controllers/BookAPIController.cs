using Books.Models;
using Books.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Controllers
{
    [ApiController]
    [Route("api/")]
    public class BookAPIController : ControllerBase
    {

        BooksServices booksServices = new BooksServices();

        [HttpGet]
        public ActionResult<IEnumerable<BookModel>> Index()
        {
            return booksServices.GetAllBooks();
        }

        [HttpGet("getBookById/{Id}")]
        public ActionResult<BookModel> MoreDetails(int Id)
        {
            return booksServices.DetailBook(Id);
        }

        [HttpGet("searchResult/{searchByTilte?}")]

        public ActionResult<IEnumerable<BookModel>> SearchResult(string searchByTilte, string searchByAuthor, string searchByGenre)
        {
            return booksServices.FoundBooks(searchByTilte, searchByAuthor, searchByGenre);
        }

        [HttpDelete("deleteBookById/{Id}")]
        public ActionResult<int> DeletePage(int Id)
        {
            BookModel book = new BookModel();
            book = booksServices.DetailBook(Id);
            return booksServices.DeleteBook(book);
        }

        [HttpPost("addNewBook")]
        public ActionResult<int> AddBookProcess(BookModel book)
        {
            return booksServices.AddBook(book);
        }
    }
}

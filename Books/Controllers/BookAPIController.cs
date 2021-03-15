using Books.Models;
using Books.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Books.Controllers
{
    [ApiController]
    [Route("api/")]
    public class BookAPIController : ControllerBase
    {
        private BooksServices booksServices = new BooksServices();

        [HttpGet]
        public ActionResult<IEnumerable<BookModel>> Index()
        {
            return booksServices.GetAllBooks();
        }

        [HttpGet("getBookById/{Id}")]
        public ActionResult<BookModelDTO> MoreDetails(int Id)
        {
            BookModel book = booksServices.DetailBook(Id);
            BookModelDTO bookDTO = new BookModelDTO(book);
            return bookDTO;
        }

        [HttpGet("searchResult/{searchByTilte?}")]
        public ActionResult<IEnumerable<BookModel>> SearchResult(string searchByTilte, string searchByAuthor, string searchByGenre)
        {
            //Only one parameter is working, didn't figure out how to put 3 parameters...
            return booksServices.FoundBooks(searchByTilte, searchByAuthor, searchByGenre);
        }

        [HttpDelete("deleteBookById/{Id}")]
        public ActionResult<int> DeletePage(int Id)
        {
            BookModel book = new BookModel();
            book = booksServices.DetailBook(Id);
            try
            {
                return booksServices.DeleteBook(book);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        [HttpPost("addNewBook")]
        public ActionResult<int> AddBookProcess(BookModel book)
        {
            return booksServices.AddBook(book);
        }
    }
}
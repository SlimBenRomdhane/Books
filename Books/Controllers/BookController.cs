using Books.Models;
using Books.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Books.Controllers
{
    public class BookController : Controller
    {
        private BooksServices BooksServices = new BooksServices();

        public IActionResult Index()
        {
            return View(BooksServices.GetAllBooks());
        }

        public IActionResult SearchPage()
        {
            return View();
        }

        public IActionResult SearchResult(string searchByTilte, string searchByAuthor, string searchByGenre)
        {
            List<BookModel> Books = new List<BookModel>();
            Books = BooksServices.FoundBooks(searchByTilte,searchByAuthor,searchByGenre);
            ViewBag.BookCout = Books.Count();
            return View("Index",Books);
        }
    }
}
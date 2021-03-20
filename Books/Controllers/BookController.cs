using Books.Models;
using Books.Services;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Collections.Generic;
using System.Linq;

namespace Books.Controllers
{
    public class BookController : Controller
    {
        private BooksServices BooksServices = new BooksServices();
        private static Logger myLogger = LogManager.GetLogger("TheLogger");
        public IActionResult Index()
        {
            ViewBag.BookCout = BooksServices.GetAllBooks().Count();
            return View(BooksServices.GetAllBooks());
        }

        public IActionResult CreateForm()
        {
            return View();
        }

        public IActionResult AddBookProcess(BookModel book)
        {
            if (ModelState.IsValid)
            {
                myLogger.Info("A new book has been added to the list");
                BooksServices.AddBook(book);
                return View("BookSuccessfullyAdded");
            }
            else
            {
                myLogger.Error("An error accured while adding a new book");
                return View("CreateForm", book);
            }
                
        }

        public IActionResult SearchPage()
        {
            return View();
        }

        public IActionResult SearchResult(string searchByTilte, string searchByAuthor, string searchByGenre)
        {
            List<BookModel> Books = new List<BookModel>();
            Books = BooksServices.FoundBooks(searchByTilte, searchByAuthor, searchByGenre);
            ViewBag.BookCout = Books.Count();
            return View("Index", Books);
        }

        public IActionResult MoreDetails(int Id)
        {
            _ = new BookModel();
            BookModel book = BooksServices.DetailBook(Id);
            return View(book);
        }

        public IActionResult JsonMoreDetails(int Id)
        {
            _ = new BookModel();
            BookModel book = BooksServices.DetailBook(Id);
            return Json(book);
        }

        public IActionResult DeletePage(int Id)
        {
            return View(BooksServices.DetailBook(Id));
        }

        public IActionResult DeleteBook(int Id)
        {
            BookModel book = new BookModel();
            book = BooksServices.DetailBook(Id);
            
            myLogger.Fatal("The book number "+ book.Id+ " has been deleted from the list");
            BooksServices.DeleteBook(book);
            return RedirectToAction("Index", "Book");
        }
    }
}
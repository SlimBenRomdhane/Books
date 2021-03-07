using Books.Services;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    public class BookController : Controller
    {
        private BooksServices BooksServices = new BooksServices();

        public IActionResult Index()
        {
            return View(BooksServices.GetAllBooks());
        }
    }
}
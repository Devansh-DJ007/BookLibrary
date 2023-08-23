using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDBContext _db;

        public BookController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Books> objBookList = _db.Books;
            return View(objBookList);
        }

        //GET
        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Create(Books b)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Add(b);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(b);
        }

        //GET
        public IActionResult Update(int? id)
        {
            if(id==null || id==0)
                return NotFound();

            var bookFromDb = _db.Books.Find(id);
            
            if(bookFromDb==null)
                return NotFound();

            return View(bookFromDb);
        }

        //POST
        [HttpPost]
        public IActionResult Update(Books b)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Update(b);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(b);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var bookFromDb = _db.Books.Find(id);

            if (bookFromDb == null)
                return NotFound();

            return View(bookFromDb);
        }

        //POST
        [HttpPost]
        public IActionResult Delete(Books b)
        {
            var bookFromDb = _db.Books.Find(b.BookId);
            if (bookFromDb == null)
                return NotFound();

            _db.Books.Remove(bookFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

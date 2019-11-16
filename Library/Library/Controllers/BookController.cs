using System;
using System.Web.Mvc;
using Library.Models.ViewModel;
using Library.Services;

namespace Library.Controllers
{
    public class BookController : Controller
    {   
        public ActionResult Index()
        {
            return View(BookServices.GetAllBooks());
        }

        public ActionResult Create()
        {
            return View(new BookViewModel());
        }

        [HttpPost]
        public ActionResult Create(BookViewModel book)
        {
            try
            {   
                BookServices.AddNewBook(book);
                return RedirectToAction("Index");
            }
            catch(Exception exception)
            {
                ViewBag.errorMessage = exception.Message;
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            BookViewModel book = (BookViewModel)BookServices.GetBook(id);
            if (book == null)
                {
                    return HttpNotFound();
                }
             return View(book);
        }

        [HttpPost]
        public ActionResult Edit(int id, BookViewModel bookUpdatedData)
        {
            try
            {
                BookServices.UpdateBook(id, bookUpdatedData);
                return RedirectToAction("Index");
            }
            catch(Exception exception)
            {
                ViewBag.errorMessage = exception.Message;
                return View();
            }
        }

        public ActionResult ConfirmDeleteBook(int id)
        {
            BookViewModel book = (BookViewModel)BookServices.GetBook(id);
            if(book == null)
                {
                    return HttpNotFound();
                }
            return PartialView("_ConfirmMessage", book);
        }

        [HttpPost]
        public ActionResult DeleteBook(int id)
        {
            try
            {
                BookServices.DeleteBook(id);
                return Json(new { redirectToUrl = Url.Action("Index", "Book") });
            }
            catch (Exception e)
            {
                return Json(new { message = e.Message });
            }
        }

    }
}

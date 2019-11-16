using System;
using System.Web.Mvc;
using Library.Models.EntityDataModel;
using Library.Models.ViewModel;
using Library.Services;

namespace Library.Controllers
{
    public class BorrowController : Controller
    {
        public ActionResult Index()
        {
            return View(BorrowServices.GetAllBorrowBooks());
        }

        public ActionResult Details(int id)
        {
            BorrowBookViewModel borrowBook = (BorrowBookViewModel)BorrowServices.GetBorrowBook(id);
            return View(borrowBook);
        }

        public ActionResult Create()
        {
                BorrowViewModel borrowViewModel = new BorrowViewModel();
                borrowViewModel.Users = UserServices.GetUsersSelectList();
                borrowViewModel.Books = BookServices.GetBooksSelectList();

                return View(borrowViewModel);
        }

        [HttpPost]
        public ActionResult Create(BorrowViewModel borrowViewModel)
        {
            try
            {
                BorrowServices.AddNewBorrow(borrowViewModel.UserId, borrowViewModel.BookId); 
                Book book = BookServices.GetBook(borrowViewModel.BookId);
                BookServices.DecreaseBookAvlaibleQuantity(book);
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult ConfirmReturnBorrowBook(int id)
        {
            BorrowBookViewModel borrowBook = (BorrowBookViewModel)BorrowServices.GetBorrowBook(id);
            if (borrowBook == null)
            {
                return HttpNotFound();
            }
            return PartialView("_ConfirmMessage", borrowBook);
        }

        [HttpPost]
        public ActionResult ReturnBorrowBook(int id)
        {
            try
            {
                BorrowServices.ReturnBook(id);
                return Json(new { redirectToUrl = Url.Action("Index", "Borrow") });
            }
            catch (Exception e)
            {
                return Json(new { message = e.Message}) ;
            }
        }
    }
}

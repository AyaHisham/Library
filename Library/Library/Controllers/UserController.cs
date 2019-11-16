using System;
using System.Web.Mvc;
using Library.Models.ViewModel;
using Library.Services;

namespace Library.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View(UserServices.GetAllUsers());
        }

        public ActionResult Create()
        {   
            return View(new UserViewModel());
        }

        [HttpPost]
        public ActionResult Create(UserViewModel user)
        {
            try
            {
                UserServices.AddNewUser(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Edit(int id)
        {
            UserViewModel user = (UserViewModel)UserServices.GetUser(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(int id, UserViewModel userUpdatedData)
        {
            try
            {
                UserServices.UpdateUser(id, userUpdatedData);           
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
       
        public ActionResult ConfirmDeleteUser(int id)
        {
            UserViewModel user =(UserViewModel)UserServices.GetUser(id);
            if (user == null)
                {
                    return HttpNotFound();
                }
            return PartialView("_ConfirmMessage",user);
        }

        [HttpPost]
        public ActionResult DeleteUser(int id)
        {        
            try
            {
                UserServices.DeleteUser(id);
                return Json(new { redirectToUrl = Url.Action("Index", "User") });
            }
            catch (Exception e)
            {
                return Json(new { message = e.Message });
            }
        }
    }
}

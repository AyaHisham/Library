using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.EntityDataModel;
using Library.Models.ViewModel;

namespace Library.Services
{
    public class UserServices
    {
        public static User GetUser(int id)
        {
            using (LibraryEntities context = new LibraryEntities())
            {
                User user = context.Users.Find(id);
                return user;
            }
        }

        public static List<User> GetAllUsers()
        {
            using (LibraryEntities context = new LibraryEntities())
            {
                return context.Users.ToList();
            }
        }

        public static SelectList GetUsersSelectList()
        {
            using (LibraryEntities context = new LibraryEntities())
            {
                var users = (from u in context.Users
                             select new { Id = u.Id, FullName = u.FirstName + " " + u.LastName }).ToList();

                return new SelectList(users, "Id", "FullName");
            }

        }

        public static void AddNewUser(UserViewModel user)
        {
            using (LibraryEntities context = new LibraryEntities())
            {
                User newUser = new User();
                newUser.Id = user.Id;
                newUser.FirstName = user.FirstName;
                newUser.LastName = user.LastName;
                newUser.PhoneNumber = user.PhoneNumber;
                context.Users.Add(newUser);
                context.SaveChanges();
            }
        }

        public static void UpdateUser(int id, UserViewModel userUpdatedData)
        {
            using (LibraryEntities context = new LibraryEntities())
            {
                User currentUser = GetUser(id);
                context.Entry(currentUser).State = EntityState.Modified;
                currentUser.Id = userUpdatedData.Id;
                currentUser.FirstName = userUpdatedData.FirstName;
                currentUser.LastName = userUpdatedData.LastName;
                currentUser.PhoneNumber = userUpdatedData.PhoneNumber;
                context.SaveChanges();
            }
        }

        public static void DeleteUser(int id)
        {
            using (LibraryEntities context = new LibraryEntities())
            {
                User currentUser = context.Users.Find(id);
                context.Users.Remove(currentUser);
                context.SaveChanges();
            }
        }
    }
}

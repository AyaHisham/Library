using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Library.Models.EntityDataModel;

namespace Library.Services
{
    public class BorrowServices
    {
        public static BorrowBooks GetBorrowBook(int id)
        {
            using (LibraryEntities context = new LibraryEntities())
            {
                BorrowBooks borrowBook = context.BorrowBooks.Include(b => b.Book).Include(u => u.User).Where(b =>b.Id == id).First();
                return borrowBook;
            }

        }

        public static List<BorrowBooks> GetAllBorrowBooks()
        {
            using (LibraryEntities context = new LibraryEntities())
            {
                List<BorrowBooks> borrowBooks = context.BorrowBooks.Include(b => b.Book).Include(u => u.User).ToList();
                return borrowBooks;
            }
        }

        public static void AddNewBorrow(int userId, int bookId) 
        {
            BorrowBooks newBorrowBook = new BorrowBooks();
            newBorrowBook.UserId = userId;
            newBorrowBook.BookId = bookId;
            newBorrowBook.BorrowDate = DateTime.Now;
            
            using (LibraryEntities context = new LibraryEntities())
            {
                context.BorrowBooks.Add(newBorrowBook);
                context.SaveChanges();
            }

         }

        public static void ReturnBook(int id)
        {
            BorrowBooks returnedBorrowBook = GetBorrowBook(id);
            int originalQuantity = returnedBorrowBook.Book.OrignalQuantity;
            int avaliableQuantity = returnedBorrowBook.Book.AvaliableQuantity + 1;
            if (BookServices.IsUnvalidQuantity(originalQuantity, avaliableQuantity)) 
            {
                throw new Exception("Avaliable Quantity More Than Original Quantity");
            }
            using (LibraryEntities context = new LibraryEntities())
            {
                BorrowBooks borrowBook = context.BorrowBooks.Find(returnedBorrowBook.Id);
                context.BorrowBooks.Remove(borrowBook);
                context.SaveChanges();
            }
            Book book = BookServices.GetBook(returnedBorrowBook.BookId);
            BookServices.IncreaseBookAvlaibleQuantity(book);
        }

    }
}

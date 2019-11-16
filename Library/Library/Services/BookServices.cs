using System;
using System.Collections.Generic;
using System.Linq;
using Library.Models.ViewModel;
using Library.Models.EntityDataModel;
using System.Data.Entity;
using System.Web.Mvc;

namespace Library.Services
{
    public class BookServices
    {
        public static Book GetBook(int id)
        {
            using (LibraryEntities context = new LibraryEntities())
            {
                Book book = context.Books.Find(id);
                return book;
            }
        }

        public static List<Book> GetAllBooks()
        {
            using (LibraryEntities context = new LibraryEntities())
            {
                return context.Books.ToList();
            }
        }

        public static List<Book> GetAllAvaliableBooks()
        {
            using (LibraryEntities context = new LibraryEntities())
            {
                List<Book> avaliableBooks = (from b in context.Books
                                             where b.AvaliableQuantity != 0
                                             select b).ToList();
                return avaliableBooks;
            }
        }

        public static SelectList GetBooksSelectList()
        {
            List<Book> avaliableBooks = GetAllAvaliableBooks();
            return new SelectList(avaliableBooks, "Id", "Name");
        }

        public static void AddNewBook(BookViewModel book)
        {
            if (IsNegativeQuantity(book))
            {
                throw new Exception("Quantity Must Be More Than Zero");
            }
            using (LibraryEntities context = new LibraryEntities())
            {
                Book newBook = new Book();
                newBook.Id = book.Id;
                newBook.Name = book.Name;
                newBook.Author = book.Author;
                newBook.Code = book.Code;
                newBook.OrignalQuantity = book.OrignalQuantity;
                //Once Created The Orignal and Avaliable Quantity is The Same.
                newBook.AvaliableQuantity = book.OrignalQuantity;
                context.Books.Add(newBook);
                context.SaveChanges();
            }

        }

        public static void UpdateBook(int id, BookViewModel bookUpdatedData)
        {
            if (IsNegativeQuantity(bookUpdatedData) || IsUnvalidQuantity(bookUpdatedData.OrignalQuantity,bookUpdatedData.AvaliableQuantity))
            {
                throw new Exception("Check Quantity");
            }
            using (LibraryEntities context = new LibraryEntities())
            {
                Book currentBook = context.Books.Find(id);
                context.Entry(currentBook).State = EntityState.Modified;
                currentBook.Id = bookUpdatedData.Id;
                currentBook.Name = bookUpdatedData.Name;
                currentBook.Author = bookUpdatedData.Author;
                currentBook.Code = bookUpdatedData.Code;
                currentBook.AvaliableQuantity = bookUpdatedData.AvaliableQuantity;
                currentBook.OrignalQuantity = bookUpdatedData.OrignalQuantity;
                context.SaveChanges();
            }
        }

        public static void DeleteBook(int id)
        {
            using (LibraryEntities context = new LibraryEntities())
            {
                Book currentBook = context.Books.Find(id);
                context.Books.Remove(currentBook);
                context.SaveChanges();
            }
        }

        public static void DecreaseBookAvlaibleQuantity(Book book)
        {
            using (LibraryEntities context = new LibraryEntities())
            {
                context.Entry(book).State = EntityState.Modified;
                book.AvaliableQuantity = book.AvaliableQuantity - 1;
                context.SaveChanges();
            }
        }

        public static void IncreaseBookAvlaibleQuantity(Book book)
        {
            using (LibraryEntities context = new LibraryEntities())
            {
                context.Entry(book).State = EntityState.Modified;
                book.AvaliableQuantity = book.AvaliableQuantity + 1;
                context.SaveChanges();
            }
        }

        public static bool IsUnvalidQuantity(int originalQuantity,int avaliableQuantity)
        {
            return (originalQuantity < avaliableQuantity);
        }

        public static bool IsNegativeQuantity(BookViewModel book)
        {
            return (book.OrignalQuantity < 0 || book.AvaliableQuantity < 0);
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using Library.Models.EntityDataModel;

namespace Library.Models.ViewModel
{
    public class BorrowBookViewModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        [Required]
        [Display(Name="Borrow Date")]
        public DateTime BorrowDate { get; set; }
        public virtual Book Book { get; set; }
        public virtual User User { get; set; }

        public static explicit operator BorrowBookViewModel(BorrowBooks borrowBook)
        {
            BorrowBookViewModel borrowBookViewModel = new BorrowBookViewModel();
            borrowBookViewModel.Id = borrowBook.Id;
            borrowBookViewModel.UserId = borrowBook.UserId;
            borrowBookViewModel.BookId = borrowBook.UserId;
            borrowBookViewModel.BorrowDate = borrowBook.BorrowDate;
            borrowBookViewModel.User = borrowBook.User;
            borrowBookViewModel.Book = borrowBook.Book;

            return borrowBookViewModel;
        }
    }
}

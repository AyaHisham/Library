using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Library.Models.EntityDataModel;

namespace Library.Models.ViewModel
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Book Name is Required")]
        [Display(Name="Book Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Author Name is Required")]
        [Display(Name = "Author Name")]
        public string Author { get; set; }

        public static explicit operator BookViewModel(List<Book> v)
        {
            throw new NotImplementedException();
        }

        [Required(ErrorMessage = "Code is Required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Quantity is Required")]
        [Display(Name = "Original Quantity")]
        public int OrignalQuantity { get; set; }
        [Required(ErrorMessage = "Quantity is Required")]
        [Display(Name = "Avialble Quantity")]
        public int AvaliableQuantity { get; set; }

        public static explicit operator BookViewModel(Book book)
        {
            BookViewModel bookViewModel = new BookViewModel();
            bookViewModel.Id = book.Id;
            bookViewModel.Name = book.Name;
            bookViewModel.Author = book.Author;
            bookViewModel.Code = book.Code;
            bookViewModel.OrignalQuantity = book.OrignalQuantity;
            bookViewModel.AvaliableQuantity = book.AvaliableQuantity;

            return bookViewModel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models.EntityDataModel
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public int OrignalQuantity { get; set; }
        [Required]
        public int AvaliableQuantity { get; set; }
        public virtual ICollection<BorrowBooks> BorrowBooks { get; set; }
    }
}

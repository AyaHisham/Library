using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.EntityDataModel
{
    public class BorrowBooks
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        [Required]
        public DateTime BorrowDate { get; set; }
        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.EntityDataModel
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public virtual ICollection<BorrowBooks> BorrowBooks { get; set; }
    }
}

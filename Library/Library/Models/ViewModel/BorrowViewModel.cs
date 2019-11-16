using System.Web.Mvc;

namespace Library.Models.ViewModel
{
    public class BorrowViewModel
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public SelectList Books { get; set; }
        public SelectList Users { get; set; }
    }
}

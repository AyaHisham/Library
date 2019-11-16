using System.Data.Entity;

namespace Library.Models.EntityDataModel
{
    public class LibraryEntities:DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BorrowBooks> BorrowBooks { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}

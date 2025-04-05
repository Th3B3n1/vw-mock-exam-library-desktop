using Microsoft.EntityFrameworkCore;

namespace KonyvtarAsztali
{
    internal class BookRepository : DbContext
    {
        private DbSet<Book> books;

        internal DbSet<Book> Books { get => books; set => books = value; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=vizsga-2022-14s-wip-db;user=root;password=");
        }
    }
}

using AppCore;
using Microsoft.EntityFrameworkCore;

namespace AppData
{
    public class AppContext : DbContext
    {
        public DbSet<Libro> Libros { get; set; }

        public DbSet<Libro> Categorias { get; set; }

        public AppContext()
        {

        }
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Libros.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                       .HasIndex(categoria => categoria.Url)
                       .IsUnique();

            modelBuilder.Entity<Libro>()
                      .HasIndex(libro => libro.Url)
                      .IsUnique();
        }
    }
}

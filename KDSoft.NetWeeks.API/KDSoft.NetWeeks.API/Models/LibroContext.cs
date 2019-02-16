using Microsoft.EntityFrameworkCore;

namespace KDSoft.NetWeeks.API.Models
{
    public class LibroContext : DbContext
    {
        public LibroContext(DbContextOptions<LibroContext> options)
            : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; }

        public DbSet<Categoria> Categorias { get; set; }
    }
}

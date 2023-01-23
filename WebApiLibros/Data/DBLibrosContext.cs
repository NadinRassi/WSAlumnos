using Microsoft.EntityFrameworkCore; //agregar el using
using WebApiLibros.Models;
using WebApiLibros.Data;

namespace WebApiLibros.Data
{
    public class DBLibrosContext: DbContext
    {   
        
        //constructor
        public DBLibrosContext(DbContextOptions<DBLibrosContext>options):base(options) {}

        //luego los dbset, propiedades

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Libro> Libros { get; set; }
    }
}

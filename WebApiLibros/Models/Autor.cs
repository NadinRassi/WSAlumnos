using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiLibros.Models
{

    [Table("Autor")]
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }


        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set;}


        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Apellido { get; set;}

        [Range(18, 110, ErrorMessage ="No cumple con el rango")] //rango desde 18 a 110

        public int? Edad { get; set;}

        public List<Libro> Libros { get; set;} // un autor tiene muchos libros

    }
}

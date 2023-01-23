using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiLibros.Models
{
    [Table("Libro")]
    public class Libro
    {
        [Key]
        public int IdLibro { get; set; }
        [Required]
        [Column(TypeName= "varchar(50)")]
        public string Titulo { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Descripcion { get; set; }


        public int AutorId { get; set; } //para la fk

        [ForeignKey("AutorId")]
        public Autor Autor { get; set; } //navegador

    }
}

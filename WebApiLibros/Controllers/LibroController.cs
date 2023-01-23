using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiLibros.Data;
using WebApiLibros.Models;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {

        private readonly DBLibrosContext context;

        public LibroController(DBLibrosContext context)
        {

            this.context = context;
        }

        //INYECCION DE DEPENDENCIA -- Termina


        /* GET—> traer todos los libros*/
        //GET: api/libro
        [HttpGet]
        public ActionResult<IEnumerable<Libro>> Get()
        {
            return context.Libros.ToList();

        }

        /* DELETE —>Eliminar libro. Retornar el libro eliminado*/
        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<Libro> Delete(int id)
        {
            var libro = (from a in context.Libros
                         where a.IdLibro == id
                         select a).SingleOrDefault();

            if (libro == null)
            {
                return NotFound();
            }

            context.Libros.Remove(libro);
            context.SaveChanges();
            return Ok();
        }

        /* PUT→modificar libro, pasado id y modelo. retornar un NoContent()*/
        //POST: api/libro
        [HttpPost]
        public ActionResult Post(Libro libro) //INSERT
        {
            if (!ModelState.IsValid)//si no es valido
            {
                return BadRequest(ModelState);//digo error
            }
            context.Libros.Add(libro);//agrego
            context.SaveChanges();//y guardo
            return Ok();
        }

        /* PUT→Traer libro por ID*/

        [HttpGet("{id}")]
        public ActionResult<Libro> GetById(int id)
        {
            var libro = (from l in context.Libros
                         where l.IdLibro == id
                         select l).SingleOrDefault();

            return libro;
        }
        /* PUT→modificar libro, pasado id y modelo. retornar un NoContent()
*/
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Libro libro)
        {
            if (id != libro.IdLibro)
            {
                return BadRequest();
            }

            context.Entry(libro).State = EntityState.Modified;

            context.SaveChanges();
            return Ok();
        }

        /* GET—>traer todos los libros por autorId*/

        [HttpGet("{IdAutor}")]
        public ActionResult<Libro>GetByAutor(int id)
        {
            Libro libro = (from l in context.Libros
                            where l.AutorId == id
                            select l).SingleOrDefault();
            return libro;
        }

    }
}

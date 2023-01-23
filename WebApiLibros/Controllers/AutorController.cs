using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebApiLibros.Data;
using WebApiLibros.Models;

namespace WebApiLibros.Controllers
{

    //se ejecutará como api/Autor
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        //INYECCION DE DEPENDENCIA --INICIA
        //propiedad
        private readonly DBLibrosContext context;

        //constructor del controlador

        public AutorController(DBLibrosContext context)
        {

            this.context = context;
        }

        //INYECCION DE DEPENDENCIA -- Termina

        //GET: api/autore
        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            return context.Autores.ToList();

        }

        //GET api/Autor/Id(EJ:5)
        [HttpGet("{id}")]
        public ActionResult<Autor> GetById(int id)//traer por id
        {
            Autor autor = (from a in context.Autores
                           where a.IdAutor == id
                           select a).SingleOrDefault();
            return autor;
        }

        [HttpGet("listado/{edad}")]//rutas personalizadas
        public ActionResult<IEnumerable<Autor>> GetEdad(int edad)
        {
            List<Autor> autores = (from a in context.Autores
                                   where a.Edad == edad
                                   select a).ToList();
            return autores;
        }


        //POST: api/autor
        [HttpPost]
        public ActionResult Post(Autor autor) //INSERT
        {
            if(!ModelState.IsValid)//si no es valido
            {
                return BadRequest(ModelState);//digo error
            }
            context.Autores.Add(autor);//agrego
            context.SaveChanges();//y guardo
            return Ok();
        }

        //UPDATE
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Autor autor)
        {
            if (id !=autor.IdAutor)
            {
                return BadRequest();
            }

            context.Entry(autor).State = EntityState.Modified;

            context.SaveChanges();
            return Ok();
        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<Autor>Delete(int id) 
        {
            var autor=(from a in context.Autores
                       where a.IdAutor == id
                       select a).SingleOrDefault();

            if(autor == null)
            {
                return NotFound();
            }

            context.Autores.Remove(autor);
            context.SaveChanges();
            return Ok();
        }

    }
}

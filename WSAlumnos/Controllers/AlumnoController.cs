using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WSAlumnos.Models;

namespace WSAlumnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private List<Alumno> Listado()
        {
            List<Alumno> alumnos = new List<Alumno>()//retorna la lista de alumnos
            {
                new Alumno(){ Id =1, Apellido="Perez", Nombre="Maria" },
                new Alumno(){ Id =2, Apellido="Rojo", Nombre="Luis" },
                new Alumno(){ Id =3, Apellido="Dorado", Nombre="Marta" }
            };

            return alumnos;
        }

        [HttpGet]
        //GET api/Alumno IEnumerable:RETORNAR UNA LISTA(Tipo interfaz q usa List)
        public IEnumerable<Alumno> GetAlumnos()
        {
            return Listado();
        }
        [HttpGet("{id}")]
        public ActionResult<Alumno> GetById(int id)// ActionResult :tipo especial q permite distintos resultados
        {
            Alumno alumno = (from a/*alumno*/ in Listado()//de alumno en Listado
                          where a.Id == id //
                          select a).SingleOrDefault(); //retornar el objeto con todas sus propiedades 
            return alumno;

        }

    }
}

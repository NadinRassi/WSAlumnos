using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using WebApiPubs.Models;
using Store = WebApiPubs.Models.Store;

namespace WebApiPubs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private pubsContext context;

        public StoreController(pubsContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Store>> Get()
        {
            return context.Stores.ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<Store> GetById(string id)
        {
            Store stores = (from s in context.Stores
                                   where s.StorId == id
                                   select s).SingleOrDefault();

            if (stores == null)
            {
                return NotFound();
            }
            return stores;
        }

        [HttpPost]
        public ActionResult Post(Store stores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Stores.Add(stores);
            context.SaveChanges();
            return Ok();
        }


        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Store stores)
        {
            if (stores.StorId != id)
            {
                return BadRequest();
            }
            context.Entry(stores).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult<Store> Delete(string id)
        {
            Store stores = (from s in context.Stores
                             where s.StorId == id
                             select s).SingleOrDefault();

            if (stores == null)
            {
                return NotFound();
            }
            context.Stores.Remove(stores);
            context.SaveChanges();
            return stores;
        }

        [HttpGet("name/{name}")]
        public ActionResult<Store> GetByName(string name)
        {
            Store stores = (from s in context.Stores
                                  where s.StorName == name
                                  select s).SingleOrDefault();
            if (stores == null)
            {
                return NotFound();
            }
            return stores;
        }


        [HttpGet("zip/{zip}")]
        public ActionResult<IEnumerable<Store>> GetByZip(string zip)
        {
            List<Store> stores = (from s in context.Stores
                                  where s.Zip == zip
                                  select s).ToList();
            if (stores == null)
            {
                return NotFound();
            }
            return stores;
        }


        [HttpGet("{city}/{state}")]
        public ActionResult<IEnumerable<Store>> GetByCityState(string city, string state)
        {
            List<Store> stores = (from s in context.Stores
                                  where s.City == city && s.State == state
                                  select s).ToList();
            if (stores.Count == 0)
            {
                return NotFound();
            }
            return stores;
        }

    }
}


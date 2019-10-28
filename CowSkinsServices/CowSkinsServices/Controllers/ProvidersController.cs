using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CowSkinsService.Models;
using CowSkinsService.DAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CowSkinsService.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProvidersController : Controller
    {
        SkinsContext db;
        public ProvidersController(SkinsContext context)
        {
            db = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Provider> GetAll()
        {
            return db.Provider.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Provider providrer = db.Provider.FirstOrDefault(x => x.IdProvider == id);
            if (providrer == null)
                return NotFound();
            return new ObjectResult(providrer);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Provider provider)
        {
            if (provider == null)
            {
                return BadRequest();
            }

            db.Provider.Add(provider);
            db.SaveChanges();
            return Ok(provider);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Provider provider = db.Provider.FirstOrDefault(x => x.IdProvider == id);
            if (provider == null)
            {
                return NotFound();
            }
            db.Provider.Remove(provider);
            db.SaveChanges();
            return Ok(provider);
        }
    }
}

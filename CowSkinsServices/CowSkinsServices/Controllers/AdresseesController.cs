using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CowSkinsService.Models;
using CowSkinsService.DAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CowSkinsService.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AdresseesController : Controller
    {
        SkinsContext db;
        public AdresseesController(SkinsContext context)
        {
            db = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Adressee> Get()
        {
            return db.Adressee.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Adressee adressee = db.Adressee.FirstOrDefault(x => x.IdAdressee == id);
            if (adressee == null)
                return NotFound();
            return new ObjectResult(adressee);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Adressee adressee)
        {
            if (adressee == null)
            {
                return BadRequest();
            }

            db.Adressee.Add(adressee);
            db.SaveChanges();
            return Ok(adressee);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]Adressee adressee)
        {
            if (adressee == null)
            {
                return BadRequest();
            }
            if (!db.Adressee.Any(x => x.IdAdressee == adressee.IdAdressee))
            {
                return NotFound();
            }

            db.Update(adressee);
            db.SaveChanges();
            return Ok(adressee);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Adressee adressee = db.Adressee.FirstOrDefault(x => x.IdAdressee == id);
            if (adressee == null)
            {
                return NotFound();
            }
            db.Adressee.Remove(adressee);
            db.SaveChanges();
            return Ok(adressee);
        }
    }
}

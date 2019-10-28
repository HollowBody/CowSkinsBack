using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CowSkinsService.DAL;
using CowSkinsService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CowSkinsService.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SortsController : Controller
    {
        SkinsContext db;
        public SortsController(SkinsContext context)
        {
            db = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Sorts> Get()
        {
            return db.Sorts.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Sorts sorts = db.Sorts.FirstOrDefault(x => x.IdSort == id);
            if (sorts == null)
                return NotFound();
            return new ObjectResult(sorts);
        }


        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Sorts sorts)
        {
            if (sorts == null)
            {
                return BadRequest();
            }

            db.Sorts.Add(sorts);
            db.SaveChanges();
            return Ok(sorts);
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
            Sorts sorts = db.Sorts.FirstOrDefault(x => x.IdSort == id);
            if (sorts == null)
            {
                return NotFound();
            }
            db.Sorts.Remove(sorts);
            db.SaveChanges();
            return Ok(sorts);
        }
    }
}

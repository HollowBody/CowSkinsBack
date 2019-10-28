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
    public class ConfigurationsController : Controller
    {
        SkinsContext db;
        public ConfigurationsController(SkinsContext context)
        {
            db = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Configuration> Get()
        {
            return db.Configuration.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Configuration configuration = db.Configuration.FirstOrDefault(x => x.IdConfiguration == id);
            if (configuration == null)
                return NotFound();
            return new ObjectResult(configuration);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Configuration configuration)
        {
            if (configuration == null)
            {
                return BadRequest();
            }

            db.Configuration.Add(configuration);
            db.SaveChanges();
            return Ok(configuration);
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
            Configuration configuration = db.Configuration.FirstOrDefault(x => x.IdConfiguration == id);
            if (configuration == null)
            {
                return NotFound();
            }
            db.Configuration.Remove(configuration);
            db.SaveChanges();
            return Ok(configuration);
        }
    }
}

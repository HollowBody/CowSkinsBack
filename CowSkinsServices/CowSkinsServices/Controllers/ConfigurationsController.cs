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
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ConfigurationsController : ControllerBase
    {
        SkinsContext _context;
        public ConfigurationsController(SkinsContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Configuration> Get()
        {
            return _context.Configuration.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Configuration configuration = _context.Configuration.FirstOrDefault(x => x.ConfigurationID == id);
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

            _context.Configuration.Add(configuration);
            _context.SaveChanges();
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
            Configuration configuration = _context.Configuration.FirstOrDefault(x => x.ConfigurationID == id);
            if (configuration == null)
            {
                return NotFound();
            }
            _context.Configuration.Remove(configuration);
            _context.SaveChanges();
            return Ok(configuration);
        }
    }
}

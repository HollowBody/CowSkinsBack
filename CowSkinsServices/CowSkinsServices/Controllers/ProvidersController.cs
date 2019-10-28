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
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProvidersController : ControllerBase
    {
        SkinsContext _context;
        public ProvidersController(SkinsContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Provider> GetAll()
        {
            return _context.Provider.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Provider providrer = _context.Provider.FirstOrDefault(x => x.ProviderID == id);
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

            _context.Provider.Add(provider);
            _context.SaveChanges();
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
            Provider provider = _context.Provider.FirstOrDefault(x => x.ProviderID == id);
            if (provider == null)
            {
                return NotFound();
            }
            _context.Provider.Remove(provider);
            _context.SaveChanges();
            return Ok(provider);
        }
    }
}

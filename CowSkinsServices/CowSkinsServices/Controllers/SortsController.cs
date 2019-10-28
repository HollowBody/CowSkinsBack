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
    public class SortsController : ControllerBase
    {
        SkinsContext _context;
        public SortsController(SkinsContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Sorts> Get()
        {
            return _context.Sorts.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Sorts sorts = _context.Sorts.FirstOrDefault(x => x.SortID == id);
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

            _context.Sorts.Add(sorts);
            _context.SaveChanges();
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
            Sorts sorts = _context.Sorts.FirstOrDefault(x => x.SortID == id);
            if (sorts == null)
            {
                return NotFound();
            }
            _context.Sorts.Remove(sorts);
            _context.SaveChanges();
            return Ok(sorts);
        }
    }
}

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
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AdresseesController : ControllerBase
    {
        SkinsContext _context;
        public AdresseesController(SkinsContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Adressee> Get()
        {
            return _context.Adressee.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Adressee adressee = _context.Adressee.FirstOrDefault(x => x.AdresseeID == id);
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

            _context.Adressee.Add(adressee);
            _context.SaveChanges();
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
            if (!_context.Adressee.Any(x => x.AdresseeID == adressee.AdresseeID))
            {
                return NotFound();
            }

            _context.Update(adressee);
            _context.SaveChanges();
            return Ok(adressee);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Adressee adressee = _context.Adressee.FirstOrDefault(x => x.AdresseeID == id);
            if (adressee == null)
            {
                return NotFound();
            }
            _context.Adressee.Remove(adressee);
            _context.SaveChanges();
            return Ok(adressee);
        }
    }
}

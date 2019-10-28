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
    public class SortingSchemesController : ControllerBase
    {
        SkinsContext _context;
        public SortingSchemesController(SkinsContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<SortingScheme> Get()
        {
            return _context.SortingScheme.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            SortingScheme sortingScheme = _context.SortingScheme.FirstOrDefault(x => x.SchemeID == id);
            if (sortingScheme == null)
                return NotFound();
            return new ObjectResult(sortingScheme);
        }

        [HttpGet]
        public int GetLastSchemeId()
        {
            var idScheme = _context.SortingScheme.Select(s => s.SchemeID).ToList();
            return idScheme.LastOrDefault();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]SortingScheme sortingScheme)
        {
            if (sortingScheme == null)
            {
                return BadRequest();
            }

            _context.SortingScheme.Add(sortingScheme);
            _context.SaveChanges();
            return Ok(sortingScheme);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

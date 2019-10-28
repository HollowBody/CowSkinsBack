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
    public class SortingSchemesController : Controller
    {
        SkinsContext db;
        public SortingSchemesController(SkinsContext context)
        {
            db = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<SortingScheme> Get()
        {
            return db.SortingScheme.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            SortingScheme sortingScheme = db.SortingScheme.FirstOrDefault(x => x.IdScheme == id);
            if (sortingScheme == null)
                return NotFound();
            return new ObjectResult(sortingScheme);
        }

        [HttpGet]
        public int GetLastSchemeId()
        {
            var idScheme = db.SortingScheme.Select(s => s.IdScheme).ToList();
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

            db.SortingScheme.Add(sortingScheme);
            db.SaveChanges();
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

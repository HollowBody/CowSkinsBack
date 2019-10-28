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
    public class SchemeTypesController : ControllerBase
    {
        SkinsContext _context;
        public SchemeTypesController(SkinsContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<SchemeType> Get()
        {
            return _context.SchemeType.ToList();
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            SchemeType schemeType = _context.SchemeType.FirstOrDefault(x => x.SchemeTypeID == id);
            if (schemeType == null)
                return NotFound();
            return new ObjectResult(schemeType);
        }


        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]SchemeType schemeType)
        {
            if (schemeType == null)
            {
                return BadRequest();
            }

            _context.SchemeType.Add(schemeType);
            _context.SaveChanges();
            return Ok(schemeType);
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
            SchemeType schemeType = _context.SchemeType.FirstOrDefault(x => x.SchemeTypeID == id);
            if (schemeType == null)
            {
                return NotFound();
            }
            _context.SchemeType.Remove(schemeType);
            _context.SaveChanges();
            return Ok(schemeType);
        }
    }
}

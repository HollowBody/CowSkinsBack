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
    public class SkinsController : ControllerBase
    {
        SkinsContext _context;
        public SkinsController(SkinsContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Skin> Get()
        {
            return _context.Skin.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Skin skin = _context.Skin.FirstOrDefault(x => x.SkinID == id);
            if (skin == null)
                return NotFound();
            return new ObjectResult(skin);
        }

        [HttpGet]
        public IActionResult GetLast()
        {
            Skin skin = _context.Skin.LastOrDefault();
            if (skin == null)
                return NotFound();
            return new ObjectResult(skin);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Skin skin)
        {
            if (skin == null)
            {
                return BadRequest();
            }

            _context.Skin.Add(skin);
            _context.SaveChanges();
            return Ok(skin);
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
            Skin skin = _context.Skin.FirstOrDefault(x => x.SkinID == id);
            if (skin == null)
            {
                return NotFound();
            }
            _context.Skin.Remove(skin);
            _context.SaveChanges();
            return Ok(skin);
        }

        [HttpGet("{batchID}")]
        public IEnumerable<Skin> GetSkinsForReport(int batchID)
        {
            var skins = _context.Skin.Where(s => s.BatchID == batchID);
            return skins;
        }
    }
}

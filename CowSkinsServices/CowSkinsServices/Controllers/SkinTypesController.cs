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
    public class SkinTypesController : ControllerBase
    {
        SkinsContext _context;
        public SkinTypesController(SkinsContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<SkinType> Get()
        {
            return _context.SkinType.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            SkinType skinType = _context.SkinType.FirstOrDefault(x => x.TypeSkinID == id);
            if (skinType == null)
                return NotFound();
            return new ObjectResult(skinType);
        }

        [HttpGet("{typeskinID}")]
        public IQueryable GetTypeSkinsLabelById(int typeskinID)
        {
            var TypeSkinLabel = _context.SkinType.Where(st => st.TypeSkinID == typeskinID)
                .Select(st => st.TypeSkinLabel);
            return TypeSkinLabel;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]SkinType skinType)
        {
            if (skinType == null)
            {
                return BadRequest();
            }

            _context.SkinType.Add(skinType);
            _context.SaveChanges();
            return Ok(skinType);
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
            SkinType skinType = _context.SkinType.FirstOrDefault(x => x.TypeSkinID == id);
            if (skinType == null)
            {
                return NotFound();
            }
            _context.SkinType.Remove(skinType);
            _context.SaveChanges();
            return Ok(skinType);
        }
    }
}

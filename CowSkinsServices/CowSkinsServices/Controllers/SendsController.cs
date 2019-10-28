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
    public class SendsController : ControllerBase
    {
        SkinsContext _context;
        public SendsController(SkinsContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Send> Get()
        {
            return _context.Send.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Send send = _context.Send.FirstOrDefault(x => x.SendID == id);
            if (send == null)
                return NotFound();
            return new ObjectResult(send);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Send send)
        {
            if (send == null)
            {
                return BadRequest();
            }

            _context.Send.Add(send);
            _context.SaveChanges();
            return Ok(send);
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
            Send send = _context.Send.FirstOrDefault(x => x.SendID == id);
            if (send == null)
            {
                return NotFound();
            }
            _context.Send.Remove(send);
            _context.SaveChanges();
            return Ok(send);
        }
    }
}

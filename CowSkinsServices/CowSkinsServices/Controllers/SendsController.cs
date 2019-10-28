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
    public class SendsController : Controller
    {
        SkinsContext db;
        public SendsController(SkinsContext context)
        {
            db = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Send> Get()
        {
            return db.Send.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Send send = db.Send.FirstOrDefault(x => x.IdSend == id);
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

            db.Send.Add(send);
            db.SaveChanges();
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
            Send send = db.Send.FirstOrDefault(x => x.IdSend == id);
            if (send == null)
            {
                return NotFound();
            }
            db.Send.Remove(send);
            db.SaveChanges();
            return Ok(send);
        }
    }
}

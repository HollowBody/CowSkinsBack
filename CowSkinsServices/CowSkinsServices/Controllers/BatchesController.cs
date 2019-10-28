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
    public class BatchesController : ControllerBase
    {
        SkinsContext _context;
        public BatchesController(SkinsContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Batch> Get()
        {
            return _context.Batch.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Batch batch = _context.Batch.FirstOrDefault(x => x.BatchID == id);
            if (batch == null)
                return NotFound();
            return new ObjectResult(batch);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Batch batch)
        {
            if (batch == null)
            {
                return BadRequest();
            }

            _context.Batch.Add(batch);
            _context.SaveChanges();
            return Ok(batch);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]Batch batch)
        {
            if (batch == null)
            {
                return BadRequest();
            }
            if (!_context.Batch.Any(x => x.BatchID == batch.BatchID))
            {
                return NotFound();
            }

            _context.Update(batch);
            _context.SaveChanges();
            return Ok(batch);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Batch batch = _context.Batch.FirstOrDefault(x => x.BatchID == id);
            if (batch == null)
            {
                return NotFound();
            }
            _context.Batch.Remove(batch);
            _context.SaveChanges();
            return Ok(batch);
        }
        
        [HttpGet("{batchID}")]
        public DateTime GetBatchOpeningDate(int batchID)
        {
            var OpeningDate = _context.Batch.Where(b => b.BatchID == batchID)
                .Select(b => b.OpeningDate).ToList();
            return OpeningDate.FirstOrDefault().Value;
        }

        [HttpGet("{batchID}")]
        public IQueryable GetBatchDebitCount(int batchID)
        {
            var DebitCount = _context.Batch.Where(b => b.BatchID == batchID)
                .Select(b => b.DebitCount);
            return DebitCount;
        }

        [HttpGet("{batchID}")]
        public int GetBatchProviderID(int batchID)
        {
            var ProviderId = _context.Batch.Where(b => b.BatchID == batchID)
                .Select(b => b.ProviderID).ToList();
            return ProviderId.FirstOrDefault().Value;
        }

        [HttpGet]
        public IQueryable GetClosedBatchesID()
        {
            var BatchesID = _context.Batch.Where(b => b.BatchStatus == "Закрыта")
                .Select(b => b.BatchID);
            return BatchesID;
        }


    }
}

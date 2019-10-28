using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KRSClientApplication.Models;
using CowSkinsService.Models;
using Microsoft.AspNetCore.Mvc;
using CowSkinsService.DAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CowSkinsService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PalletsController : ControllerBase
    {
        private SkinsContext _context;
        public PalletsController(SkinsContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Pallet> Get()
        {
            return _context.Pallet.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Pallet pallet = _context.Pallet.FirstOrDefault(x => x.PalletID == id);
            if (pallet == null)
                return NotFound();
            return new ObjectResult(pallet);
        }

        [HttpGet("{status}")]
        public IEnumerable<PalletAdvancedView> GetWithStatus(string status)
        {
            var pallet = _context.Pallet
                .Join(_context.SkinType, p => p.TypeSkinID, skinType => skinType.TypeSkinID, (p, skinType) => new { p, skinType })
                .Where(p => p.p.Status == status)
                .Select(palletSelect => new PalletAdvancedView()
                {
                    PalletID = palletSelect.p.PalletID,
                    OpeningDate = palletSelect.p.OpeningDate,
                    ClosingDate = palletSelect.p.ClosingDate,
                    SendingDate = palletSelect.p.SendingDate,
                    Status = palletSelect.p.Status,
                    CurrentCountSkins = palletSelect.p.CurrentCountSkins,
                    TypeSkinID = palletSelect.p.TypeSkinID,
                    SkinTypeLabel = palletSelect.skinType.TypeSkinLabel
                });
            return pallet.ToList();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Pallet pallet)
        {
            if (pallet == null)
            {
                return BadRequest();
            }

            _context.Pallet.Add(pallet);
            _context.SaveChanges();
            return Ok(pallet);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]Pallet pallet)
        {
            if (pallet == null)
            {
                return BadRequest();
            }
            if (!_context.Pallet.Any(x => x.PalletID == pallet.PalletID))
            {
                return NotFound();
            }

            _context.Update(pallet);
            _context.SaveChanges();
            return Ok(pallet);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Pallet pallet = _context.Pallet.FirstOrDefault(x => x.PalletID == id);
            if (pallet == null)
            {
                return NotFound();
            }
            _context.Pallet.Remove(pallet);
            _context.SaveChanges();
            return Ok(pallet);
        }
    }
}

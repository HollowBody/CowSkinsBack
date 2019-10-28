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
    [Route("api/[controller]/[action]")]
    public class PalletsController : Controller
    {
        private SkinsContext _db;
        public PalletsController(SkinsContext context)
        {
            _db = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Pallet> Get()
        {
            return _db.Pallet.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Pallet pallet = _db.Pallet.FirstOrDefault(x => x.IdPallet == id);
            if (pallet == null)
                return NotFound();
            return new ObjectResult(pallet);
        }

        [HttpGet("{status}")]
        public IEnumerable<PalletAdvancedView> GetWithStatus(string status)
        {
            var pallet = _db.Pallet
                .Join(_db.SkinType, p => p.IdTypeSkin, skinType => skinType.IdTypeSkin, (p, skinType) => new { p, skinType })
                .Where(p => p.p.Status == status)
                .Select(palletSelect => new PalletAdvancedView()
                {
                    IdPallet = palletSelect.p.IdPallet,
                    OpeningDate = palletSelect.p.OpeningDate,
                    ClosingDate = palletSelect.p.ClosingDate,
                    SendingDate = palletSelect.p.SendingDate,
                    Status = palletSelect.p.Status,
                    CurrentCountSkins = palletSelect.p.CurrentCountSkins,
                    IdTypeSkin = palletSelect.p.IdTypeSkin,
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

            _db.Pallet.Add(pallet);
            _db.SaveChanges();
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
            if (!_db.Pallet.Any(x => x.IdPallet == pallet.IdPallet))
            {
                return NotFound();
            }

            _db.Update(pallet);
            _db.SaveChanges();
            return Ok(pallet);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Pallet pallet = _db.Pallet.FirstOrDefault(x => x.IdPallet == id);
            if (pallet == null)
            {
                return NotFound();
            }
            _db.Pallet.Remove(pallet);
            _db.SaveChanges();
            return Ok(pallet);
        }
    }
}

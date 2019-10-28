using System.Collections.Generic;
using System.Linq;
using KRSClientApplication.Models;
using CowSkinsService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using CowSkinsService.DAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CowSkinsService.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CostJournalsController : Controller
    {
        private readonly SkinsContext _db;
        public CostJournalsController(SkinsContext context)
        {
            _db = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<CostJournal> Get()
        {
            return _db.CostJournal.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            CostJournal costJournal = _db.CostJournal.FirstOrDefault(x => x.IdCost == id);
            if (costJournal == null)
                return NotFound();
            return new ObjectResult(costJournal);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]CostJournal costJournal)
        {
            if (costJournal == null)
            {
                return BadRequest();
            }

            _db.CostJournal.Add(costJournal);
            _db.SaveChanges();
            return Ok(costJournal);
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
            CostJournal costJournal = _db.CostJournal.FirstOrDefault(x => x.IdCost == id);
            if (costJournal == null)
            {
                return NotFound();
            }
            _db.CostJournal.Remove(costJournal);
            _db.SaveChanges();
            return Ok(costJournal);
        }

        [HttpGet]
        public IEnumerable<Skin> GetBatch()
        {
            var closedBatchIdList = _db.Batch.Where(b => b.BatchStatus == "Закрыта").Select(b => b.IdBatch);
            List<int> ids = closedBatchIdList.ToList();
            var skinsToCost = _db.Skin.ToList();
            var result = skinsToCost.FindAll(s => ids.Contains(s.IdBatch.Value));
            return result;
        }

        [HttpGet("{batchID}")]
        public IEnumerable<CostJournalAdvancedView> GetCostingByBatchId(int batchID)
        {
            var costJournal = _db.CostJournal
                .Join(_db.SkinType, cj => cj.IdTypeSkin, skinType => skinType.IdTypeSkin, (cj, skinType) => new { cj, skinType })
                .Where(cj => cj.cj.IdBatch == batchID)
                .Select(costJoutnalSelect => new CostJournalAdvancedView()
                {
                    IdBatch = costJoutnalSelect.cj.IdBatch,
                    IdCost=costJoutnalSelect.cj.IdCost,
                    CostDate =costJoutnalSelect.cj.CostDate,
                    IdSort = costJoutnalSelect.cj.IdSort,
                    SkinPrice = costJoutnalSelect.cj.SkinPrice,
                    TypeSkinLabel = costJoutnalSelect.skinType.TypeSkinLabel,
                    IdTypeSkin = costJoutnalSelect.cj.IdTypeSkin
                });
            return costJournal;
        }

        [HttpGet]
        public List<SkinType> GetTypeSkins()
        {
            var idTypeSkin = _db.SkinType.ToList();
            return idTypeSkin;
        }

        [HttpGet("{batchNumber}")]
        public IEnumerable<Skin> GetSkinsinBatch(int batchNumber)
        {
            var skins = _db.Skin.Where(s => s.IdBatch == batchNumber).OrderBy(s=>s.IdTypeSkin).ThenBy(s=>s.IdSort).ToList();
            return skins;
        }

        [HttpGet("{batchNumber}")]
        public IEnumerable<CostingSelect> GetCurrentBatchesSkins(int batchNumber)
        {
            var currentBatchesSkins = _db.Skin
                .Join(_db.SkinType, skin => skin.IdTypeSkin, skinType => skinType.IdTypeSkin, (s, skinType) => new { s, skinType })
               .Where(idbatch => idbatch.s.IdBatch == batchNumber)
                .Select(sortingSelect => new CostingSelect
                {
                    IdBatch = sortingSelect.s.IdBatch,
                    IdTypeSkin = sortingSelect.s.IdTypeSkin,
                    IdSort = sortingSelect.s.IdSort,
                    Brutto = sortingSelect.s.Brutto,
                    Discount = sortingSelect.s.Discount,
                    IdConfiguration = sortingSelect.s.IdConfiguration,
                    IdPallet = sortingSelect.s.IdPallet,
                    IdSkin = sortingSelect.s.IdSkin,
                    Netto = sortingSelect.s.Netto,
                    SkinTypeLabel = sortingSelect.skinType.TypeSkinLabel
                }).OrderBy(s => s.IdTypeSkin).ThenBy(s => s.IdSort);

            return currentBatchesSkins.ToList();
        }

        [HttpGet("{batchNumber}")]
        public IEnumerable<CostingSelect> GetCurrentBatchesDistinctSkins(int batchNumber)
        {
            var currentBatchesSkins = _db.Skin
                .Join(_db.SkinType, skin => skin.IdTypeSkin, skinType => skinType.IdTypeSkin, (s, skinType) => new { s, skinType })
                .Where(idbatch => idbatch.s.IdBatch == batchNumber)
                .Select(sortingSelect => new CostingSelect
                {
                    IdBatch = sortingSelect.s.IdBatch,
                    IdTypeSkin = sortingSelect.s.IdTypeSkin,
                    IdSort = sortingSelect.s.IdSort,
                    Brutto = sortingSelect.s.Brutto,
                    Discount = sortingSelect.s.Discount,
                    IdConfiguration = sortingSelect.s.IdConfiguration,
                    IdPallet = sortingSelect.s.IdPallet,
                    IdSkin = sortingSelect.s.IdSkin,
                    Netto = sortingSelect.s.Netto,
                    SkinTypeLabel = sortingSelect.skinType.TypeSkinLabel
                }).OrderBy(s => s.IdTypeSkin).ThenBy(s => s.IdSort).Distinct((skin, skin1) => skin.IdTypeSkin == skin1.IdTypeSkin).OrderBy(s => s.IdTypeSkin).ThenBy(s => s.IdSort);

            return currentBatchesSkins.ToList();
        }
    }
}

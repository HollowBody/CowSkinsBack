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
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CostJournalsController : ControllerBase
    {
        private readonly SkinsContext _context;
        public CostJournalsController(SkinsContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<CostJournal> Get()
        {
            return _context.CostJournal.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            CostJournal costJournal = _context.CostJournal.FirstOrDefault(x => x.CostID == id);
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

            _context.CostJournal.Add(costJournal);
            _context.SaveChanges();
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
            CostJournal costJournal = _context.CostJournal.FirstOrDefault(x => x.CostID == id);
            if (costJournal == null)
            {
                return NotFound();
            }
            _context.CostJournal.Remove(costJournal);
            _context.SaveChanges();
            return Ok(costJournal);
        }

        [HttpGet]
        public IEnumerable<Skin> GetBatch()
        {
            var closedBatchIdList = _context.Batch.Where(b => b.BatchStatus == "Закрыта").Select(b => b.BatchID);
            List<int> ids = closedBatchIdList.ToList();
            var skinsToCost = _context.Skin.ToList();
            var result = skinsToCost.FindAll(s => ids.Contains(s.BatchID.Value));
            return result;
        }

        [HttpGet("{batchID}")]
        public IEnumerable<CostJournalAdvancedView> GetCostingByBatchId(int batchID)
        {
            var costJournal = _context.CostJournal
                .Join(_context.SkinType, cj => cj.TypeSkinID, skinType => skinType.TypeSkinID, (cj, skinType) => new { cj, skinType })
                .Where(cj => cj.cj.BatchID == batchID)
                .Select(costJoutnalSelect => new CostJournalAdvancedView()
                {
                    BatchID = costJoutnalSelect.cj.BatchID,
                    CostID=costJoutnalSelect.cj.CostID,
                    CostDate =costJoutnalSelect.cj.CostDate,
                    SortID = costJoutnalSelect.cj.SortID,
                    SkinPrice = costJoutnalSelect.cj.SkinPrice,
                    TypeSkinLabel = costJoutnalSelect.skinType.TypeSkinLabel,
                    TypeSkinID = costJoutnalSelect.cj.TypeSkinID
                });
            return costJournal;
        }

        [HttpGet]
        public List<SkinType> GetTypeSkins()
        {
            var idTypeSkin = _context.SkinType.ToList();
            return idTypeSkin;
        }

        [HttpGet("{batchNumber}")]
        public IEnumerable<Skin> GetSkinsinBatch(int batchNumber)
        {
            var skins = _context.Skin.Where(s => s.BatchID == batchNumber).OrderBy(s=>s.TypeSkinID).ThenBy(s=>s.SortID).ToList();
            return skins;
        }

        [HttpGet("{batchNumber}")]
        public IEnumerable<CostingAdvancedView> GetCurrentBatchesSkins(int batchNumber)
        {
            var currentBatchesSkins = _context.Skin
                .Join(_context.SkinType, skin => skin.TypeSkinID, skinType => skinType.TypeSkinID, (s, skinType) => new { s, skinType })
               .Where(idbatch => idbatch.s.BatchID == batchNumber)
                .Select(sortingSelect => new CostingAdvancedView
                {
                    BatchID = sortingSelect.s.BatchID,
                    TypeSkinID = sortingSelect.s.TypeSkinID,
                    SortID = sortingSelect.s.SortID,
                    Brutto = sortingSelect.s.Brutto,
                    Discount = sortingSelect.s.Discount,
                    ConfigurationID = sortingSelect.s.ConfigurationID,
                    PalletID = sortingSelect.s.PalletID,
                    SkinID = sortingSelect.s.SkinID,
                    Netto = sortingSelect.s.Netto,
                    SkinTypeLabel = sortingSelect.skinType.TypeSkinLabel
                }).OrderBy(s => s.TypeSkinID).ThenBy(s => s.SortID);

            return currentBatchesSkins.ToList();
        }

        [HttpGet("{batchNumber}")]
        public IEnumerable<CostingAdvancedView> GetCurrentBatchesDistinctSkins(int batchNumber)
        {
            var currentBatchesSkins = _context.Skin
                .Join(_context.SkinType, skin => skin.TypeSkinID, skinType => skinType.TypeSkinID, (s, skinType) => new { s, skinType })
                .Where(idbatch => idbatch.s.BatchID == batchNumber)
                .Select(sortingSelect => new CostingAdvancedView
                {
                    BatchID = sortingSelect.s.BatchID,
                    TypeSkinID = sortingSelect.s.TypeSkinID,
                    SortID = sortingSelect.s.SortID,
                    Brutto = sortingSelect.s.Brutto,
                    Discount = sortingSelect.s.Discount,
                    ConfigurationID = sortingSelect.s.ConfigurationID,
                    PalletID = sortingSelect.s.PalletID,
                    SkinID = sortingSelect.s.SkinID,
                    Netto = sortingSelect.s.Netto,
                    SkinTypeLabel = sortingSelect.skinType.TypeSkinLabel
                }).OrderBy(s => s.TypeSkinID).ThenBy(s => s.SortID).Distinct((skin, skin1) => skin.TypeSkinID == skin1.TypeSkinID).OrderBy(s => s.TypeSkinID).ThenBy(s => s.SortID);

            return currentBatchesSkins.ToList();
        }
    }
}

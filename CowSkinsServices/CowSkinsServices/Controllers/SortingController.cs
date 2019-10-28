using System;
using System.Collections.Generic;
using System.Linq;
using CowSkinsService.DAL;
using CowSkinsService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CowSkinsService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SortingController : ControllerBase
    {
        SkinsContext _context;

        public SortingController(SkinsContext context)
        {
            _context = context;
        }

        //[HttpGet/*("{currentBatchNumber}")*/]
        //public IQueryable GetCurrentBatchesSkins(/*int currentBatchNumber*/)
        [HttpGet("{batchNumber}")]
        public IEnumerable<SortingAdvancedView> GetCurrentBatchesSkins(int batchNumber)
        {
            var currentBatchesSkins = _context.Skin
                .Join(_context.Batch, skin => skin.BatchID, batch => batch.BatchID, (skin, batch) => new { skin, batch })
                .Join(_context.SkinType, s => s.skin.TypeSkinID, skinType => skinType.TypeSkinID, (s, skinType) => new { s, skinType })
                .Join(_context.Pallet, s => s.s.skin.PalletID, pallet => pallet.PalletID, (s, pallet) => new { s, pallet })
                .Where(idbatch => idbatch.s.s.batch.BatchID == batchNumber)
                .Select(sortingSelect => new SortingAdvancedView()
                {
                    Sort = sortingSelect.s.s.skin.SortID,
                    Brutto = sortingSelect.s.s.skin.Brutto,
                    Netto = sortingSelect.s.s.skin.Netto,
                    Discount = sortingSelect.s.s.skin.Discount,
                    SkinTypeLabel = sortingSelect.s.skinType.TypeSkinLabel,
                    MaximumCountSkin = sortingSelect.s.skinType.MaximumCountSkin,
                    BatchID = sortingSelect.s.s.batch.BatchID,
                    SkinID = sortingSelect.s.s.skin.SkinID,
                    PalletID = sortingSelect.pallet.PalletID,
                    CurrentCount = sortingSelect.pallet.CurrentCountSkins
                });

            return currentBatchesSkins.ToList();
        }
        // CQRS - Command Query Responsibility Segrregation

        // GET: api/values
        [HttpGet]
        public IQueryable GetOpenBatches()
        {
            var openBatches = _context.Batch.Where(b => b.BatchStatus == "Открыта")
                   .Select(s => s.BatchID);
            return openBatches;
        }

        [HttpGet("{weight},{idconfiguration}")]
        public IQueryable GetConfigurationTypeSkin(float weight, int idconfiguration)
        {
            var typeSkin = _context.SkinType.Where(st => st.MinimumWeight <= Convert.ToDecimal(weight) && st.MaximumWeight >= Convert.ToDecimal(weight) && st.IdConfiguration == idconfiguration)
                .Select(st => st.TypeSkinID);
            return typeSkin;
        }

        [HttpGet("{idtypeskin}")]
        public IQueryable GetTypeSkinPallet(int idtypeskin)
        {
            var IDpallet = _context.Pallet.Where(p => p.Status == "Открыт" && p.TypeSkinID == idtypeskin)
                .Select(p => p.PalletID);
            return IDpallet;
        }

        [HttpGet("{batchNumber}")]
        public int GetSchemeID(int batchNumber)
        {
            var IDScheme = _context.Batch.Where(b => b.BatchID == batchNumber)
                .Select(b => b.SchemeID).ToList();
            return IDScheme.First().Value;
        }

        [HttpGet("{schemeID}")]
        public IQueryable GetEnabledTypeSkins(int schemeID)
        {
            var IDTypeSkin = _context.SchemeType.Where(st => st.SchemeID == schemeID)
                .Select(st => st.TypeSkinID);
            return IDTypeSkin;
        }

        [HttpGet("{palletID}")]
        public int GetPalletCountSkins(int palletID)
        {
            var CurrentCount = _context.Pallet.Where(p => p.PalletID == palletID)
                .Select(p => p.CurrentCountSkins).ToList();
            return CurrentCount.FirstOrDefault().Value;
        }

        [HttpGet("{palletID}")]
        public DateTime GetPalletOpeningDate(int palletID)
        {
            var OpeningDate = _context.Pallet.Where(p => p.PalletID == palletID)
                .Select(p => p.OpeningDate).ToList();
            return OpeningDate.FirstOrDefault().Value;
        }

        [HttpGet("{typeskinID}")]
        public int GetMaxCountSkins(int typeskinID)
        {
            var MaxCount = _context.SkinType.Where(st => st.TypeSkinID == typeskinID)
                .Select(st => st.MaximumCountSkin).ToList();
            return MaxCount.FirstOrDefault().Value;
        }

        [HttpGet("{configName}")]
        public int GetConfigurationID(string configName)
        {
            var IDConfiguration = _context.Configuration.Where(c => c.ConfigurationLabel == configName)
                .Select(c => c.ConfigurationID).ToList();
            return IDConfiguration.FirstOrDefault();
        }

        [HttpGet("{batchID}")]
        public IEnumerable<Batch> GetBatch(int batchID)
        {
            var CurrentBatch = _context.Batch.Where(b => b.BatchID == batchID);
            return CurrentBatch;
        }
    }
}

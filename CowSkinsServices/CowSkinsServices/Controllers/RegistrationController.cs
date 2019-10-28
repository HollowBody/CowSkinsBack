using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CowSkinsService.DAL;
using CowSkinsService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CowSkinsService.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RegistrationController : Controller
    {
        SkinsContext db;
        public RegistrationController(SkinsContext context)
        {
            db = context;
        }
        [HttpGet]
        public IEnumerable<ProviderAdvancedView> GetProviders()
        {
            var providers = db.Provider.Select(providerSelect => new ProviderAdvancedView
            {
                IdProvider = providerSelect.IdProvider,
                ProviderLabel = providerSelect.ProviderLabel
            });
            return providers.ToList();
        }
    }
}

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
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RegistrationController : ControllerBase
    {
        SkinsContext _context;
        public RegistrationController(SkinsContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<ProviderAdvancedView> GetProviders()
        {
            var providers = _context.Provider.Select(providerSelect => new ProviderAdvancedView
            {
                ProviderID = providerSelect.ProviderID,
                ProviderLabel = providerSelect.ProviderLabel
            });
            return providers.ToList();
        }
    }
}

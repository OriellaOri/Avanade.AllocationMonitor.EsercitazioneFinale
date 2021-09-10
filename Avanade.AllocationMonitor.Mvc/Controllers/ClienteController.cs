using Avanade.AllocationMonitor.Core.BusinessLayers;
using Microsoft.AspNetCore.Mvc;
using Avanade.AllocationMonitor.Mvc.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avanade.AllocationMonitor.Core.Enums;

namespace Avanade.AllocationMonitor.Mvc.Controllers
{
    public class ClienteController : Controller
    {
        private readonly MainBusinessLayer bl;

        public ClienteController()
        {
            bl = new MainBusinessLayer();
        }

        public IActionResult Index()
        {
            var model = bl.FetchAllClienti();

            ViewBag.Priorities = Help.EnumToSelectList<DimensioneAzienda>();

            return View(model.ToViewModel());
        }
    }
}

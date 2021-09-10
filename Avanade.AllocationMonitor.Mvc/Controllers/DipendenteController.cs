using Avanade.AllocationMonitor.Core.BusinessLayers;
using Microsoft.AspNetCore.Mvc;
using Avanade.AllocationMonitor.Mvc.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avanade.AllocationMonitor.Mvc.Models;

namespace Avanade.AllocationMonitor.Mvc.Controllers
{
    public class DipendenteController : Controller
    {
        private readonly MainBusinessLayer bl;

        public DipendenteController()
        {
            bl = new MainBusinessLayer();
        }

        // GET : visualizzo tutta la lista
        // dei dipendenti presenti nello storage  
        public IActionResult Index()
        {
            // recupero la lista dei dipendenti
            var model = bl.FetchAllDipendenti();

            //la passo a lista di Dipendenti 
            // trasformandola in una lista di DipendentiListViewModel
            return View(model.ToViewModel());
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: TicketsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DipendentiCreateViewModel dipendente)
        {
            try
            {
                if (dipendente == null)
                    return View("Error");

                var result = bl.CreateDipendente(dipendente.ToDipendente());

                if (result == null)
                    return View("Error");

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

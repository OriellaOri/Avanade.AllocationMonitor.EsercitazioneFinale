using Avanade.AllocationMonitor.Core.BusinessLayers;
using Microsoft.AspNetCore.Mvc;
using Avanade.AllocationMonitor.Mvc.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}

using Avanade.AllocationMonitor.Core.BusinessLayers;
using Microsoft.AspNetCore.Mvc;
using Avanade.AllocationMonitor.Mvc.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avanade.AllocationMonitor.Mvc.Models;
using Microsoft.AspNetCore.Http;
using Avanade.AllocationMonitor.Core.Entities;

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

        // POST
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

        public ActionResult Details(int id)
        {
            if (id <= 0)
                return View("Error");

            var model = bl.GetDipendenteById(id);

            if (model == null)
                return View("Error");

            return View(model);
        }

        // GET
        public ActionResult Edit(int id)
        {
            if (id <= 0)
                return View("Error");

            var model = bl.GetDipendenteById(id);          

            return View(model.ToEditViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, DipendentiCreateViewModel dipendente)
        {
            try
            {
                if (dipendente == null)
                    return View("Error");

                var result = bl.UpdateDipendente(dipendente.ToDipendente());

                if (result == null)
                    return View("Error");

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return View("Error");

            var model = bl.GetDipendenteById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection data)
        {
            try
            {
                if (id <= 0)
                    return View("Error");

                Dipendente dipendeteCanellare = bl.GetDipendenteById(id);
                var result = bl.DeleteDipendente(dipendeteCanellare);

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

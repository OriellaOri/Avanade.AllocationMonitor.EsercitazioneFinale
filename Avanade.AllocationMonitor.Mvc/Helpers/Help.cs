using Avanade.AllocationMonitor.Core.Entities;
using Avanade.AllocationMonitor.Mvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avanade.AllocationMonitor.Mvc.Helpers
{
    public static class Help
    {
        /// <summary>
        /// Rendere un dipendente 
        /// un dipendenteViewModel
        /// </summary>
        /// <param name="dipendente"></param>
        /// <returns></returns>
        public static DipendentiListViewModel ToViewModel(this Dipendente dipendente)
        {
            return new DipendentiListViewModel
            {
                Id = dipendente.Id,
                Nome = dipendente.Nome,
                Cognome = dipendente.Cognome,
                Email = dipendente.Email,
                DataNascita = dipendente.DataNascita.ToString("yyyy-MMM-dd"),
                DataInizioProfessione = dipendente.DataInizioProfessione.ToString("yyyy-MMM-dd"),
                CostoOrario = dipendente.CostoOrario,
                NomeMansione = dipendente.Mansione.Nome
            };
        }

        /// <summary>
        /// Rende una lista di Dipendenti 
        /// una lista di DipendentiVM
        /// </summary>
        /// <param name="dipendenti"></param>
        /// <returns></returns>
        public static IEnumerable<DipendentiListViewModel> ToViewModel(this IEnumerable<Dipendente> dipendenti)
        {
            return dipendenti.Select(d => d.ToViewModel());
        }

        public static Dipendente ToDipendente(this DipendentiCreateViewModel d)
        {
            return new Dipendente
            {
                Nome = d.Nome,
                Cognome = d.Cognome,
                Email = d.Email,
                DataNascita = d.DataNascita,
                DataInizioProfessione = d.DataInizioProfessione,
                CostoOrario = d.CostoOrario,
                Mansione = new Mansione { Id = 1, Nome = d.Mansione }
            };
        }

        public static DipendentiCreateViewModel ToEditViewModel(this Dipendente d)
        {
            return new DipendentiCreateViewModel
            {
                Id = d.Id,
                Nome = d.Nome,
                Cognome = d.Cognome,
                Email = d.Email,
                DataNascita = d.DataNascita,
                DataInizioProfessione = d.DataInizioProfessione,
                CostoOrario = d.CostoOrario,
                Mansione = d.Mansione.Nome
            };
        }


        public static ClientiListViewModel ToViewModel(this Cliente cliente)
        {
            return new ClientiListViewModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Citta = cliente.Citta,
                Regione = cliente.Regione,
                Provincia = cliente.Provincia,
                Dimensione = cliente.Dimensione,
                NomeRiferimento = cliente.NomeRiferimento,
                EmailRiferimento = cliente.EmailRiferimento
            };
        }


        public static IEnumerable<ClientiListViewModel> ToViewModel(this IEnumerable<Cliente> clienti)
        {
            return clienti.Select(c => c.ToViewModel());
        }

        public static IEnumerable<SelectListItem> EnumToSelectList<T>() where T : struct
        {
            return (Enum.GetValues(typeof(T)).Cast<T>().Select(
                e => new SelectListItem() { Text = e.ToString(), Value = e.ToString() })).ToList();
        }
    }
}


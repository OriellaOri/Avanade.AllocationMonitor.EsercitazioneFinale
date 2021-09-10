using Avanade.AllocationMonitor.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Avanade.AllocationMonitor.Mvc.Models
{
    public class DipendentiListViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Required]
        [StringLength(255)]
        public string Cognome { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        public string DataNascita { get; set; }

        [Required]
        public string DataInizioProfessione { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double CostoOrario { get; set; }

        [DisplayName("Mansione")]
        public string NomeMansione { get; set; }
    }
}

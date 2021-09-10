using Avanade.AllocationMonitor.Core.Entities;
using Avanade.AllocationMonitor.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Avanade.AllocationMonitor.Mvc.Models
{
    public class DipendentiCreateViewModel
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
        public DateTime DataNascita { get; set; }

        [Required]
        public DateTime DataInizioProfessione { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double CostoOrario { get; set; }

        //[Required]
        public virtual string Mansione { get; set; }
    }
}

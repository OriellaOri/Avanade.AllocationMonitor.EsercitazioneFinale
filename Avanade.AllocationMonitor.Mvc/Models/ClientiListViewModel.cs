using Avanade.AllocationMonitor.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Avanade.AllocationMonitor.Mvc.Models
{
    public class ClientiListViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Required]
        [StringLength(255)]
        public string Citta { get; set; }

        [Required]
        [StringLength(255)]
        public string Regione { get; set; }

        [Required]
        [StringLength(255)]
        public string Provincia { get; set; }

        [Required]
        public DimensioneAzienda Dimensione { get; set; }

        [StringLength(255)]
        public string NomeRiferimento { get; set; }

        [StringLength(255)]
        public string EmailRiferimento { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Avanade.AllocationMonitor.Mvc.Models
{
    public class UserLoginViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Username")]
        public string UserName { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string FirstName { get; set; }

        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        public bool IsEnabled { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        public bool IsAdministrator { get; set; }

        public string ReturnUrl { get; set; }
    }
}

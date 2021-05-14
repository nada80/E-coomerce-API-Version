using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APi_version.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Column(TypeName = "nvarchar(70)")]
        public string FullName { get; set; }
      
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public string Role { get; set; }
    }
}

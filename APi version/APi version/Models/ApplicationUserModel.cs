using System;
using System.Collections.Generic;
<<<<<<< Updated upstream
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
=======
>>>>>>> Stashed changes
using System.Linq;
using System.Threading.Tasks;

namespace APi_version.Models
{
    public class ApplicationUserModel
    {
<<<<<<< Updated upstream
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FullName { get; set; }


=======
>>>>>>> Stashed changes
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APi_version.Models
{
    public class Product 
    {
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string ProductName { get; set; }
        public double price { get; set; }
        [Required]
        public string Description { get; set; }
        public string Color { get; set; }
        public string Size { get; set; } 
        [Required]
        [DisplayName("Product Image")]
        public string Image { get; set; }
        [Required]
        public int Quantity { get; set; } 

        [ForeignKey("category")]
        public int CategoryID { get; set; }

        public virtual Category category { get; set; }

        [ForeignKey("brand")]
        public int BrandID { get; set; }
        public virtual Brands brand { get; set; }
    }
}

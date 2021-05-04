using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APi_version.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CategoryName { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}

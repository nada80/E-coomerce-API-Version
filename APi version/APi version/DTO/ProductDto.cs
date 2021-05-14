using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APi_version.DTO
{
    public class ProductDto
    {
        public string ProductName { get; set; }
        public double price { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
    }
}

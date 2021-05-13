using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static APi_version.Models.AppDBContext;

namespace APi_version.Models
{
    public class Order
    {
        public int ID { get; set; }

        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }

        [ForeignKey("Users")]
        public string ApplicationUser_Id { get; set; }
        public virtual ApplicationUser Users { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();



    }
}

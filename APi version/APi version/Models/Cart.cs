using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static APi_version.Models.AppDBContext;

namespace APi_version.Models
{
    public class Cart
    {
        public int ID { get; set; }

        [ForeignKey("users")]
        public string UserID { get; set; }
        public virtual ApplicationUser users { get; set; }

        public virtual List<CartItem> cartItems { get; set; } = new List<CartItem>();

    }
}

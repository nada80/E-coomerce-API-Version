using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static APi_version.Models.AppDBContext;

namespace APi_version.Models
{
    public class Cart
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }
        [Key]
        public int CartId { get; set; }

        [ForeignKey("users")]
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }

    }
}

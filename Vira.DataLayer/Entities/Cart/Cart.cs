using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berlance.DataLayer.Entities.Cart
{
    public class Cart
    {
        [Key] 
        public int CartId { get; set; }

        [Required]
        public DateTime InsertTime { get; set; }= DateTime.Now;
        public DateTime? UpdateTime { get; set; }
        public bool IsDelete { get; set; } = false;
        public DateTime? DeleteTime { get; set; }
        public bool Finished { get; set; }
        public int SumAmount { get; set; }

        #region Relations
        public User.User User { get; set; }
        public int? UserId { get; set; }

        public Guid BrowserId { get; set;  }
        public ICollection<CartItem> CartItems { get; set; }

        #endregion
    }
}

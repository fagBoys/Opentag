using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berlance.DataLayer.Entities.Cart
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }

        [Required]
        public DateTime InsertTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
        public bool IsDelete { get; set; } = false;
        public DateTime? DeleteTime { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }

        #region Relations
        public virtual Storage.Storage Storage { get; set; }
        public int StorageId { get; set; }

        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }



        #endregion

    }
}

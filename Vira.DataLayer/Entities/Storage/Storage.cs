using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Berlance.DataLayer.Entities.Order;
using Berlance.DataLayer.Entities.Product;

namespace Berlance.DataLayer.Entities.Storage
{
    public class Storage
    {
        [Key]
        public int StorageId { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product.Product Product { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CountProduct { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Price { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Size { get; set; }

        [Required]
        public int ColorId { get; set; }
        [ForeignKey("ColorId")]
        public Colors Colors { get; set; }

        public bool IsDelete { get; set; }

        public DateTime RegisterDate { get; set; }

        public ICollection<Image> Images { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

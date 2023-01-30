using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vira.DataLayer.Entities;

namespace Vira.DataLayer.Entities.Order
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        [Required(ErrorMessage = "مقدار {0} خالی است")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "مقدار {0} خالی است")]
        public int StorageId { get; set; }

        [Required(ErrorMessage = "مقدار {0} خالی است")]
        public int Price { get; set; }

        [Required(ErrorMessage = "مقدار {0} خالی است")]
        public int Count { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [ForeignKey("StorageId")]
        public Storage.Storage Storage { get; set; }

        public ICollection<ProductReturn.ProductReturn> ProductReturns { get; set; }
    }
}

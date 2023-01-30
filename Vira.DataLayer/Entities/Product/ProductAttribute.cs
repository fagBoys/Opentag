using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vira.DataLayer.Entities.Product
{
    public class ProductAttribute
    {
        [Key]
        public int ProductAttributeId { get; set; }

        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        public int AttributeId { get; set; }

        [ForeignKey("AttributeId")]
        public Attribut Attribut { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Berlance.DataLayer.Entities.Product;

namespace Berlance.Core.DTOs.Product
{
    public class ShowproductListItemViewModel
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public Image Image { get; set; }
        public List<string> ColorsName { get; set; }
        public int Price { get; set; }
        public int? Discount { get; set; }
    }
}

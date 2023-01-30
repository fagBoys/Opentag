using Berlance.DataLayer.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Berlance.DataLayer.Entities;
using Berlance.DataLayer.Entities.Cart;

namespace Berlance.Core.DTOs.Product
{
    public class DetailProductViewModel
    {
        public string Title { get; set; }

        public Image PrimaryImage { get; set; }

        public List<Image> AllImages { get; set; }

        public List<DataLayer.Entities.Storage.Storage> Storages { get; set; }

        public ProductGroup Group { get; set; }

        public ProductGroup SubGroup { get; set; }

        public IEnumerable<Colors> Colors { get; set; }

        public IEnumerable<CartItem> CartItems { get; set; }

        public IEnumerable<ProductAttributesViewModel> Attributs { get; set; }

        public string Description { get; set; }

        public DataLayer.Entities.Storage.Storage StorageSelected { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vira.DataLayer.Entities.Product;

namespace Vira.Core.DTOs.Product
{
    public class ShowProductForAdminViewModel
    {
        public int ProductId { get; set; }
        public string ImageName { get; set; }
        public string Titel { get; set; }
        public List<string> Size { get; set; }
        public List<string> Color { get; set; }
        public int StorageCount { get; set; }
        

    }
}

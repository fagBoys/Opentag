using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vira.Core.DTOs.Product;
using Vira.DataLayer.Entities;
using Vira.DataLayer.Entities.Slider;
using Vira.DataLayer.Entities.Support;

namespace Vira.Core.DTOs.Home
{
    public class IndexViewModel
    {
        public List<ShowproductListItemViewModel> ProductsList { get; set; }

        public List<Slider> Sliders { get; set; }
        public  List<MessengerSupport> MessengerSupports { get; set; }
        public string Ip { get; set; }
    }
}

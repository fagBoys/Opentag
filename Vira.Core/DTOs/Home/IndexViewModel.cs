using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Berlance.Core.DTOs.Product;
using Berlance.DataLayer.Entities;
using Berlance.DataLayer.Entities.Slider;
using Berlance.DataLayer.Entities.Support;

namespace Berlance.Core.DTOs.Home
{
    public class IndexViewModel
    {
        public List<ShowproductListItemViewModel> ProductsList { get; set; }

        public List<Slider> Sliders { get; set; }
        public  List<MessengerSupport> MessengerSupports { get; set; }
        public string Ip { get; set; }
    }
}

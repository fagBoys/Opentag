using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vira.DataLayer.Entities.Slider
{
    public class Slider
    {
        [Key]
        public int SliderId { get; set; }

        [Required]
        public string ImageName { get; set; }

        [Required]
        public string PhoneImageName { get; set; }

        [Required]
        public string ButtonText { get; set; }

        [Required]
        public string Linke { get; set; }

    }
}

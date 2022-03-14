using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Opentag.ViewModels
{
    public class AddOrderViewModel
    {

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Phone Number: ")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmailAddress { get; set; }

        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(200)]
        public string Discription { get; set; }

    }
}

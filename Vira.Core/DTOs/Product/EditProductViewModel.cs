using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berlance.Core.DTOs.Product
{
    public class EditProductViewModel
    {
        [Required]
        public string ProductTitle { get; set; }

        [Required]
        public int GroupId { get; set; }

        [Required]
        public int SubGroup { get; set; }

        [Required]
        public List<int> AttributeId { get; set; }
    }
}

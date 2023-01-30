using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berlance.Core.DTOs.Storage
{
    public class AddStorageViewModel
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int CountProduct { get; set; }
        [Required]
        public int Price { get; set; }
        
        public string Size { get; set; }
        [Required]
        public int ColorId { get; set; }
        [Required]
        public List<string> Files { get; set; }
    }
}

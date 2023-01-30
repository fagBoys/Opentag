using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vira.Core.DTOs.Product
{
    public class CreateProductViewModel
    {

        [Required]
        public string ProductTitle { get; set; }

        [Required]
        public int GroupId { get; set; }

        [Required]
        public int SubGroup { get; set; }


        [Required]
        public string ProductDescription { get; set; }

        public List<int>? AttributeId { get; set; }

    }
}

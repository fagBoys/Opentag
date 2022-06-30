using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Opentag.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ImageName { get; set; }

        public bool Primary { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }

    }
}

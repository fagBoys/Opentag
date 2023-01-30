using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Berlance.DataLayer.Entities.Article
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
      
        [Required]
        public string Title { get; set; }

        [Required]
        public string Title2 { get; set; }

        [Required]
        public string Tage { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }

        public int?  View { get; set; }
        
       
        [MaxLength(100)]
        public string? ImageName { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;



        public IEnumerable<ArticleComment> ArticleComments  { get; set; }
    }
}

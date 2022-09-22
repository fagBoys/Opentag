using Microsoft.AspNetCore.Http;
using Opentag.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Opentag.ViewModels.Article
{
    public class AddArticleViewModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string AuthorName { get; set; }
        
        [Required]
        public IFormFile PostImage { get; set; }

        public IEnumerable<IFormFile> Album { get; set; }

        [Required]
        [MaxLength(200)]
        public string ShortBody { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Body { get; set; }

        public IEnumerable<string> Tags { get; set; }

    }
}

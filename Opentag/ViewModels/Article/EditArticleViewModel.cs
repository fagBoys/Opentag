using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Opentag.Models;
using Microsoft.AspNetCore.Http;

namespace Opentag.ViewModels.Article
{
    public class EditArticleViewModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string AuthorName { get; set; }

        public IFormFile PostImage { get; set; }

        public IEnumerable<IFormFile> Album { get; set; }

        [Required]
        [MaxLength(200)]
        public string ShortBody { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Body { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public Models.Article TargetArticle { get; set; }

        public List<Image> TargetAlbum { get; set; }
    }
}

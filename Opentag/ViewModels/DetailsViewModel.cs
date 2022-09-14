using Opentag.Data;
using Opentag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opentag.ViewModels
{
    public class DetailsViewModel
    {

        public DetailsViewModel()
        {
            ApplicationDbContext Context = new ApplicationDbContext();

            Articles = Context.Article.OrderByDescending(A => A.ArticleId).Take(4).Select(A =>
            new IndexArticlesViewModel
            {

                ArticleId = A.ArticleId,
                ArticleTitle = A.Title

            }).ToList();
        }

        public Models.Article article { get; set; }

        public IEnumerable<Models.Article> articlesList { get; set; }

        public IEnumerable<IndexArticlesViewModel> Articles { get; set; }


    }
}

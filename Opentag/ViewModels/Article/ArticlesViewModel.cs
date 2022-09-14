using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opentag.ViewModels.Article
{
    public class ArticlesViewModel
    {
        public string PostImage { get; set; }

        public string Title { get; set; }

        public string ShortBody { get; set; }

        public string AuthorName { get; set; }

        public DateTime Date { get; set; }
    }
}

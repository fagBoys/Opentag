using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opentag.Models
{
    public class ArticleTag
    {
        public int ArticleTagId { get; set; }

        public int TagId { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }

        public Tag Tags { get; set; }



    }
}

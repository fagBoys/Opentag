using Berlance.DataLayer.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Berlance.DataLayer.Entities.Article;

namespace Berlance.Core.DTOs.Comment
{
    public class ShowCommentArticle
    {
        //public List<ArticleComment> ArticleComments { get; set; }
        //public List<ArticleAnswerComment> ArticleAnswerComments { get; set; }

        public int ArticleCommentId  { get; set; }
        public string ArticleComment { get; set; }
        public string ArticleAnswerComment { get; set; }
        public DateTime CarateDateTime { get; set; }
        public string UserName { get; set; }
        public string UserAvatar { get; set; }
        public int ArticleId { get; internal set; }
    }
}

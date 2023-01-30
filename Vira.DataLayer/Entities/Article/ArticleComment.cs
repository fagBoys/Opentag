using Vira.DataLayer.Entities.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vira.DataLayer.Entities.Article
{
    public class ArticleComment
    {

        [Key]
        public int CommentId { get; set; }

        [Required]
        public int ArticleId { get; set; }

        [Required]
        public int UserId { get; set; }

        public int? AnswerId { get; set; }

        [Required]
        [MaxLength(700)]
        public string Comment { get; set; }

        public DateTime CarateDateTime { get; set; }

        public bool IsDelete { get; set; }

        public bool IsAdminRead { get; set; }

        #region Relation

        public Article Article { get; set; }
        public User.User User { get; set; }

        [ForeignKey("AnswerId")]
        public ArticleAnswerComment ArticleAnswerComment { get; set; }

        public List<ArticleCommentLike> ArticleCommentLike { get; set; }

        #endregion


    }
}

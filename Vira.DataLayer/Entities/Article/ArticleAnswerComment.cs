using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vira.DataLayer.Entities.Article
{
    public class ArticleAnswerComment
    {
        [Key]
        public int AnswerId { get; set; }

        [Required]
        [MaxLength(700)]
        public string Answer { get; set; }

        #region Relation
        [Required]
        public int CommentID { get; set; }

        [ForeignKey("CommentID")]
        public ArticleComment ArticleComment { get; set; }

        [Required]
        public int UserId { get; set; }
        public User.User User { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
        #endregion

    }
}

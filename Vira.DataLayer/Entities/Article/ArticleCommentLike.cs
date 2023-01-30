using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Berlance.DataLayer.Entities.Article
{
    public class ArticleCommentLike
    {
        [Key]
        public int ArtilcleCommentLikeId { get; set; }

        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User.User User { get; set; }

        [Required]
        public int CommentId { get; set; }
        [ForeignKey("CommentId")]
        public ArticleComment ArticleComment { get; set; }




    }
}

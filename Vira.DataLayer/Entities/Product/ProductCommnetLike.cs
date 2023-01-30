using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Berlance.DataLayer.Entities.Article;

namespace Berlance.DataLayer.Entities.Product
{
    public class ProductCommnetLike
    {

        [Key]
        public int ProductCommentLikeId { get; set; }

        [Required]
        public int UserId { get; set; }
        public User.User User { get; set; }

        [Required]
        public int CommentId { get; set; }
        [ForeignKey("CommentId")]
        public ProductComment ProductComment { get; set; }

        

    }
}

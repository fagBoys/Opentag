using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berlance.DataLayer.Entities.Product
{
    public class ProductComment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public int ProductId { get; set; }

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

        public Product Product { get; set; }
        public User.User User { get; set; }
        [ForeignKey("AnswerId")]
        public AnswerComment AnswerComment { get; set; }

        public ProductCommnetLike ProductCommnetLike { get; set; }
        #endregion
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berlance.DataLayer.Entities.Product
{
    public class AnswerComment
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
        public ProductComment ProductComment { get; set; }

        [Required]
        public int UserId { get; set; }
        public User.User User { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
        #endregion
    }
}
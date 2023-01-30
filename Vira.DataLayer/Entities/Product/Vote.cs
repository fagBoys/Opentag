using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berlance.DataLayer.Entities.Product
{
    public class Vote
    {
        [Key]
        public int VoteId { get; set; }

        [Required]
        public int ManyVote { get; set; }

        #region Relations

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int UserId { get; set; }
        public User.User User { get; set; }


        #endregion


    }
}

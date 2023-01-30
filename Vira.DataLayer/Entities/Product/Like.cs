using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vira.DataLayer.Entities.Product
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int UserId { get; set; }
        public User.User User { get; set; }
    }
}
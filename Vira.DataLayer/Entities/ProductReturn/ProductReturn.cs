using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vira.DataLayer.Entities.Order;

namespace Vira.DataLayer.Entities.ProductReturn
{
    public class ProductReturn
    {
        [Key]
        public int ReturnId { get; set; }

        [Required]
        public string Reason { get; set; }

        [MaxLength(100)]
        [Required]
        public string ImageName { get; set; }

        [MaxLength(200)]
        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        [Required]
        public DateTime ReturnUpdateDate { get; set; }

        [Required]
        public bool verified { get; set; }

        #region Relation

        public int OrderDetailId { get; set; }
        public OrderDetail OrderDetail { get; set; }

        public int UserId { get; set; }
        public User.User User { get; set; }

        #endregion
    }
}

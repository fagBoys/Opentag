using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vira.DataLayer.Entities.payment
{
    public class RequestPay
    {
        [Key]
        public Guid RequestId { get; set; }
        public int Amount { get; set; }
        public bool IsPay { get; set; }
        public DateTime? PayDate { get; set; }
        public string? Authority { get; set; }
        public long RefId { get; set; } = 0; 



        #region Relations

        public User.User User { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<Order.Order> Orders { get; set; }
        #endregion





    }
}

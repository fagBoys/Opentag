using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Berlance.DataLayer.Entities.payment;
using Berlance.DataLayer.Entities.User;

namespace Berlance.DataLayer.Entities.Order
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "مقدار {0} خالی است")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "مقدار {0} خالی است")]
        public int Sum { get; set; }

        [Required(ErrorMessage = "مقدار {0} خالی است")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "مقدار {0} خالی است")]
        public string Address { get; set; }

        public OrdarState ordarState { get; set; }


        #region Relations

        [ForeignKey("UserId")]
        public User.User OrderUser { get; set; }

        public RequestPay RequestPay { get; set; }
        public Guid RequestId { get; set; }


        public ICollection<OrderDetail> OrderDetails { get; set; }

        #endregion

        public enum OrdarState
        {
            [Display(Name = "درحال پردازش")]
            Processing = 0,
            [Display(Name = "لغو شده")]
            Canceled = 1,
            [Display(Name = "ارسال شده")]
            Delivered = 2
        }
    }
}

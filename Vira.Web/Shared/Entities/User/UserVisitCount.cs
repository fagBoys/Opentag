using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vira.Web.Shared.Entities.User
{
    public class UserVisitCount
    {
        [Key]
        public int UserLogCountId { get; set; }

        [Display(Name = "شناسه کاربر")]
        [MaxLength(150, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [MinLength(6, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد .")]
        public int UserId { get; set; }

        [Display(Name = "تاریخ بازدید")]
        public DateTime LastVisitDate { get; set; }

        #region Relations
        [ForeignKey("UserId")]
        public User User { get; private set; }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Berlance.DataLayer.Entities.User;

namespace Berlance.DataLayer.Entities.Cart
{
    public class Discount
    {
        [Key]
        public int  DiscountId { get; set; }
        [Required]
        [MaxLength(150)]
        public string DIscountCode { get; set; }
        [Required]
        public int  DiscountPercent { get; set; }

        public int? UsableCount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public List<UserDiscountCode> UserDiscountCodes { get; set; }

    }
}

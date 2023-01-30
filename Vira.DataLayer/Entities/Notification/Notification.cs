using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vira.DataLayer.Entities.Notification
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public bool Available { get; set; }

        public bool Off { get; set; }

        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        User.User  user { get; set; }

        [Required] 
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product.Product Product { get; set; }
    }

}

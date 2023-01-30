using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vira.DataLayer.Entities.Notification
{
    public class ArticleNotification
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
    }
}

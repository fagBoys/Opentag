using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vira.DataLayer.Entities.Support
{
    public class MessengerSupport
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Ip { get; set; }

        [Required]
        public Guid BrowserId { get; set; }

        public int? UserId { get; set; }

        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime SendMessageDate { get; set; }
        [Required]
        public int IdAdmin { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public bool IsReplay { get; set; }

        #region Relations

        //[ForeignKey("UserId")]
        //public User.User User { get; set; }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vira.DataLayer.Entities.User
{
    public class VisiteCount
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Ip { get; set; }
        [Required]
        public DateTime DateVisite { get; set; } = DateTime.Now;
    }
}

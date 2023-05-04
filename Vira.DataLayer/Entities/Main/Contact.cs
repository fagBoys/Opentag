using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vira.DataLayer.Entities.Main
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        public string Fullname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Subject { get; set; }

        public string Text { get; set; }
    }
}

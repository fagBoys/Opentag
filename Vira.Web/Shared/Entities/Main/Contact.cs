using System.ComponentModel.DataAnnotations;

namespace Vira.Web.Shared.Entities.Main
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
        public DateTime ContactDate { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Vira.Web.Shared.Entities.Main
{
    public class VisitHomePage
    {
        [Key]
        public long VisitId { get;  set; }
        [Required]
        [Display(Name = "آی پی کاربر")]
        public string Ip { get; set; }

        [Display(Name = "تاریخ بازدید")]
        public DateTime VisitDate { get;  set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vira.Web.Shared.Entities.permissions
{
    public class permission
    {
        [Key]
        public int permissionId { get; set; }

        [Display(Name = "عنوان نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string permissionTitel { get; set; }
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public List<permission> Permissions { get; set; }

        public List<RolePermission> RolePermissions { get; set; }
    }
}

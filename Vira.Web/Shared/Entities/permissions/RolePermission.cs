using System.ComponentModel.DataAnnotations;
using Vira.Web.Shared.Entities.User;

namespace Vira.Web.Shared.Entities.permissions
{
    public class RolePermission
    {
        [Key]
        public int RP_Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        public Role Role { get; set; }
        public permission Permission { get; set; }
    }
}

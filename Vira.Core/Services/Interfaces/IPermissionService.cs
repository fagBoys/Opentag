using System;
using System.Collections.Generic;
using System.Text;
using vira.DataLayer.Entities.permissions;
using Vira.DataLayer.Entities.User;

namespace Vira.Core.Services.Interfaces
{
    public interface IPermissionService
    {
        #region Roles
        List<Role> GetRoles();
        int AddRole(Role role);
        Role GetRoleById(int RoleId);
        void UpdateRole(Role role);
        void DeleteRole(Role role);
        void AddRolesToUser(List<int> roleIds, int userId);
        void EditRolesUser(int userId, List<int> rolesId);

        #endregion

        #region Permission

        List<permission> GetAllPermissions();
        void AddPermissionsToRole(int roleid, List<int> permission);
        List<int> permissionRole(int roleid);
        void UpdatePermissionsRole(int roleid, List<int> permissions);
        bool CheckPermission(int permissionId, string username);

        #endregion
    }
}

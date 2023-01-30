using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Berlance.Core.Services.Interfaces;
using Berlance.DataLayer.Context;
using Berlance.DataLayer.Entities.permissions;
using Berlance.DataLayer.Entities.User;

namespace Berlance.Core.Services
{
    public class PermissionService : IPermissionService
    {
        private BerLanceContext _context;

        public PermissionService(BerLanceContext context)
        {
            _context = context;
        }
        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public int AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role.RoleId;
        }

        public Role GetRoleById(int RoleId)
        {
            return _context.Roles.Find(RoleId);
        }

        public void UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
        }

        public void DeleteRole(Role role)
        {
            role.IsDelete = true;
            UpdateRole(role);
        }

        public void AddRolesToUser(List<int> roleIds, int userId)
        {
            foreach (int roleId in roleIds)
            {
                _context.UserRoles.Add(new UserRole()
                {
                    RoleId = roleId,
                    UserId = userId
                });
            }

            _context.SaveChanges();
        }

        public void EditRolesUser(int userId, List<int> rolesId)
        {
            //Delete All Roles User
            _context.UserRoles.Where(r => r.UserId == userId).ToList().ForEach(r => _context.UserRoles.Remove(r));

            //Add New Roles
            AddRolesToUser(rolesId, userId);
        }

        public List<permission> GetAllPermissions()
        {
            return _context.Permission.ToList();
        }

        public void AddPermissionsToRole(int roleid, List<int> permission)
        {
            foreach (var p in permission)
            {
                _context.RolePermission.Add(new RolePermission()
                {
                    PermissionId = p,
                    RoleId = roleid
                });
                _context.SaveChanges();
            }
        }

        public List<int> permissionRole(int roleid)
        {
            return _context.RolePermission
                .Where(P => P.RoleId == roleid)
                .Select(R => R.PermissionId).ToList();
        }

        public void UpdatePermissionsRole(int roleid, List<int> permissions)
        {
            _context.RolePermission.Where(P => P.RoleId == roleid)
                .ToList().ForEach(P => _context.RolePermission.Remove(P));
            AddPermissionsToRole(roleid, permissions);
        }

        public bool CheckPermission(int permissionId, string username)
        {
            int userid = _context.Users.Single(U => U.UserName == username).UserId;

            List<int> UserRoles = _context.UserRoles
                .Where(R => R.UserId == userid).Select(R => R.RoleId).ToList();
            if (!UserRoles.Any())
                return false;
            List<int> RolesPermission = _context.RolePermission
                .Where(R => R.PermissionId == permissionId)
                .Select(R => R.RoleId).ToList();

            return RolesPermission.Any(P => UserRoles.Contains(P));
        }
    }
}
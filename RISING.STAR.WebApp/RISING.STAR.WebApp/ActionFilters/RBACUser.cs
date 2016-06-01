using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RISING.STAR.WebApp.Models;
using RISING.STAR.DAL;

namespace RISING.STAR.WebApp.ActionFilters
{
    public class RBACUser
    {
        
        public Guid User_Id { get; set; }
        public bool IsSysAdmin { get; set; }
        public string Username { get; set; }
        private List<UserRole> Roles = new List<UserRole>();

        public RBACUser(string _username)
        {
            this.Username = _username;
            this.IsSysAdmin = false;
            GetDatabaseUserRolesPermissions();
        }

        public RBACUser(Guid _userid)
        {
            this.User_Id = _userid;
            this.IsSysAdmin = false;
            GetDatabaseUserRolesPermissions(_userid);
        }

        private void GetDatabaseUserRolesPermissions()
        {
            using (RBAC_Model _data = new RBAC_Model())
            {
                User _user = _data.USERS.Where(u => u.Login == this.Username).FirstOrDefault();
                if (_user != null)
                {
                    this.User_Id = _user.Guid;
                    foreach (Role _role in _user.Roles)
                    {
                        UserRole _userRole = new UserRole { Role_Id = _role.RoleGUID, RoleName = _role.RoleDescription };
                        foreach (Permission _permission in _role.Permissions)
                        {
                            _userRole.Permissions.Add(new RolePermission { Permission_Id = _permission.PermissionGUID, PermissionDescription = _permission.PermissionDescription });
                        }
                        this.Roles.Add(_userRole);

                        if (!this.IsSysAdmin)
                            this.IsSysAdmin =  _role.IsSysAdmin;
                    }
                }
            }
        }

        private void GetDatabaseUserRolesPermissions(Guid _userID)
        {
            using (RBAC_Model _data = new RBAC_Model())
            {
                User _user = _data.USERS.Where(u => u.Guid == _userID).FirstOrDefault();
                if (_user != null)
                {
                    this.User_Id = _user.Guid;
                    foreach (Role _role in _user.Roles)
                    {
                        UserRole _userRole = new UserRole { Role_Id = _role.RoleGUID, RoleName = _role.RoleDescription };
                        foreach (Permission _permission in _role.Permissions)
                        {
                            _userRole.Permissions.Add(new RolePermission { Permission_Id = _permission.PermissionGUID, PermissionDescription = _permission.PermissionDescription });
                        }
                        this.Roles.Add(_userRole);

                        if (!this.IsSysAdmin)
                            this.IsSysAdmin = _role.IsSysAdmin;
                    }
                }
            }
        }

        public bool HasPermission(string requiredPermission)
        {
            bool bFound = false;
            foreach (UserRole role in this.Roles)
            {
                bFound = (role.Permissions.Where(
                          p => p.PermissionDescription == requiredPermission).ToList().Count > 0);
                if (bFound)
                    break;
            }
            return bFound;
        }

        public bool HasRole(string role)
        {
            return (Roles.Where(p => p.RoleName == role).ToList().Count > 0);
        }

    }

    public class UserRole
    {
        public Guid Role_Id { get; set; }
        public string RoleName { get; set; }
        public List<RolePermission> Permissions = new List<RolePermission>();
    }

    public class RolePermission
    {
        public Guid Permission_Id { get; set; }
        public string PermissionDescription { get; set; }
    }


    
}
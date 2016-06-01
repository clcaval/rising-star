using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RISING.STAR.WebApp.ActionFilters
{
    public static class RBAC_ExtendedMethods
    {

        public static bool HasRole(this ControllerBase controller, string role)
        {
            bool Found = false;
            try
            {
                //Check if the requesting user has the specified role...
                if (controller.ControllerContext.HttpContext.Session["UserID"] != null)
                {
                    Found = new RBACUser(Guid.Parse(controller.ControllerContext.HttpContext.Session["UserID"].ToString())).HasRole(role);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return Found;
        }

        public static bool HasPermission(this ControllerBase controller, string permission)
        {
            bool Found = false;
            try
            {
                //Check if the requesting user has the specified application permission...
                Found = new RBACUser(controller.ControllerContext
                                     .HttpContext.User.Identity.Name).HasPermission(permission);
            }
            catch { }
            return Found;
        }

        public static bool IsSysAdmin(this ControllerBase controller)
        {
            bool IsSysAdmin = false;
            try
            {
                //Check if the requesting user has the System Administrator privilege...
                IsSysAdmin = new RBACUser(controller.ControllerContext
                                          .HttpContext.User.Identity.Name).IsSysAdmin;
            }
            catch { }
            return IsSysAdmin;
        }

    }
}
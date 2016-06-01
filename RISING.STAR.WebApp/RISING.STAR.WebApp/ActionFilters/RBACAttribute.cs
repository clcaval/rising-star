using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RISING.STAR.WebApp.ActionFilters
{
    public class RBACAttribute : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            /*Create permission string based on the requested controller 
              name and action name in the format 'controllername-action'*/
            string requiredPermission = String.Format("{0}-{1}",
                   filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                   filterContext.ActionDescriptor.ActionName);

            /*Create an instance of our custom user authorisation object passing requesting 
              user's 'Windows Username' into constructor*/
            var context = new System.Web.HttpContextWrapper(System.Web.HttpContext.Current);
            Guid idUser = new Guid();
            if (context.Session["UserID"] != null)
                idUser = Guid.Parse(context.Session["UserID"].ToString());

            RBACUser requestingUser = new RBACUser(idUser);

            //Check if the requesting user has the permission to run the controller's action
            if (!requestingUser.HasPermission(requiredPermission) & !requestingUser.IsSysAdmin)
            {
                /*Roledoesn't have the required permission and is not a SysAdmin, return our 
                  custom '401 Unauthorized' access error. Since we are setting 
                  filterContext.Result to contain an ActionResult page, the controller's 
                  action will not be run.

                  The custom '401 Unauthorized' access error will be returned to the 
                  browser in response to the initial request.*/

                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    action = "Index",
                    controller = "Unauthorised",
                    area = ""
                }));


            }
            /*If the user has the permission to run the controller's action, then 
              filterContext.Result will be uninitialized and executing the controller's 
              action is dependant on whether filterContext.Result is uninitialized.*/
        }

    }
}
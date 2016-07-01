using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RISING.STAR.DAL;
using System.Web.Mvc;

namespace RISING.STAR.WebApp.Areas.UserAndRole.Models
{
    public class UserViewModel
    {

        public User user { get; set; }

        public Guid SelectedRole { get; set; }
        public List<SelectListItem> Roles { get; set; }

    }
}
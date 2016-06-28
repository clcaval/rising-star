using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RISING.STAR.DAL;
using RISING.STAR.Utils.Password;

namespace RISING.STAR.Business.Common
{
    public class CommonBusiness : BusinessBase
    {

        public bool CheckLogin(String user, String password)
        {

            var userExists = dbContext.UserTests.Where(x => x.UserName == user).FirstOrDefault();
            if (userExists != null)
            {
                var passwordsMatch = PasswordCreation.ValidatePassword(password, userExists.PasswordHash);
                return passwordsMatch;
            }
            else
                return false;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryWebApp.Models;

namespace InventoryWebApp.Management
{
    public static class AuthenticationManagement
    {
        public static void MarkUserAsAuthenticated(UserDTO authUser, bool auth)
        {
            if(authUser != null)
                HttpContext.Current.Session[$"{authUser.UserName}-{authUser.ID}-isAuth"] = auth;
        }

        public static void StoreCurrentUser(UserDTO authUser)
        {
            HttpContext.Current.Session["CurrentUser"] = authUser;
        }

        public static UserDTO GetCurrentUser()
        {
            var currentUser = HttpContext.Current.Session["CurrentUser"];

            if (currentUser == null)
                return null;
            else
                return (UserDTO) currentUser;
        }

        public static CompanyDTO GetCurrentUserCompany()
        {
            UserDTO currentUser = GetCurrentUser();

            CompanyDTO currentCompany = (CompanyDTO) HttpContext.Current.Session["CurrentCompany"];

            // Check if company was stored in session to prevent another trip to the DB
            if(currentCompany == null)
            {
                currentCompany = UserManagement.GetUserCompany(currentUser);
                HttpContext.Current.Session["CurrentCompany"] = currentCompany;
            }

            return currentCompany;
        }

        public static bool IsUserAuthenticated(UserDTO authUser)
        {
            var result = HttpContext.Current.Session[$"{authUser.UserName}-{authUser.ID}-isAuth"];

            if (result != null && (bool) result == true)
                return true;
            else
                return false;
        }

        public static bool IsCurrentUserAdmin()
        {
            UserDTO currentUser = GetCurrentUser();
            CompanyDTO currentCompany = GetCurrentUserCompany();

            RoleDTO userRole = CompanyUserManagement.GetCompanyUserRole(currentCompany.ID, currentUser.ID);

            return userRole.Role == Roles.Admin;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool IsCurrentUserAuthenticated()
        {
            var currentUser = GetCurrentUser();

            if (currentUser == null)
                return false;

            return IsUserAuthenticated(currentUser);
        }
    }
}
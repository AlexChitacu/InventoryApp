using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventoryWebApp.Utils;
using InventoryWebApp.Management;
using InventoryWebApp.Models;

namespace InventoryWebApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CompanyUsersPage.Visible = false;

            // Don't display Links
            if (!AuthenticationManagement.IsCurrentUserAuthenticated())
            {
                InventoryPage.Visible = false;
                LogoutButton.Visible = false;
            }

            if(AuthenticationManagement.IsCurrentUserAuthenticated())
            {
                InventoryPage.Visible = true;
                LogoutButton.Visible = true;

                LogInLink.Visible = false;

                if(AuthenticationManagement.IsCurrentUserAdmin())
                {
                    CompanyUsersPage.Visible = true;
                }
            }
        }

        protected void LogOut(object sender, EventArgs e)
        {
            UserDTO authUser = AuthenticationManagement.GetCurrentUser();

            AuthenticationManagement.MarkUserAsAuthenticated(authUser, false);

            Response.Redirect("~/Pages/LogInForm");
        }
    }
}
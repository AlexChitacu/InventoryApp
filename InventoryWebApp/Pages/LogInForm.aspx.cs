using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventoryWebApp.Models;
using InventoryWebApp.Utils;
using InventoryWebApp.Management;

namespace InventoryWebApp.Pages
{
    public partial class LogInForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorMessage.Visible = false;

            if (IsUserAlreadyLoggedIn())
            {
                ErrorMessage.Visible = true;
                ErrorMessage.InnerText = "Already logged in!";

                User.Visible = false;
                UserPassword.Visible = false;
                formSubmit.Visible = false;
            }

        }

        public void FormSubmit(object sender, EventArgs e)
        {
            UserDTO existingUser = new UserDTO();
            existingUser.UserName = User.Value;
            existingUser.UserPassword = Cypher.HashStringWithSalt(UserPassword.Value);

            if(UserManagement.CheckIfUserExists(existingUser))
            {
                ErrorMessage.InnerText = "Successfully LoggedIn";
                ErrorMessage.Visible = true;

                UserDTO authUser = UserManagement.GetUserByName(existingUser.UserName);

                AuthenticationManagement.StoreCurrentUser(authUser);
                AuthenticationManagement.MarkUserAsAuthenticated(authUser, true);

                Response.Redirect("~/");
            }
            else
            {
                ErrorMessage.InnerText = "Invalid User!";
                ErrorMessage.Visible = true;
            }
        }

        public bool IsUserAlreadyLoggedIn()
        {
            UserDTO authUser = AuthenticationManagement.GetCurrentUser();

            if (authUser != null)
                return AuthenticationManagement.IsUserAuthenticated(authUser);
            else
                return false;
        }
    }
}
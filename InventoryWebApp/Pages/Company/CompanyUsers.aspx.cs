using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventoryWebApp.Management;
using InventoryWebApp.Models;
using InventoryWebApp.Utils;

namespace InventoryWebApp.Pages.Company
{
    public partial class CompanyUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorMessage.Visible = false;

            ShowUsers();

            if(!IsPostBack)
            {
                UserRole.DataSource = GeneralManagement.GetAllRoles();
                UserRole.DataBind();
            }
        }

        protected void FormSubmit(object sender, EventArgs e)
        {
            CompanyDTO currentCompany = AuthenticationManagement.GetCurrentUserCompany();

            UserDTO newUser = new UserDTO();
            newUser.UserName = UserName.Value;
            newUser.Email = UserEmail.Value;
            newUser.UserPassword = Cypher.HashStringWithSalt(UserPassword.Value);

            string role = UserRole.Items[UserRole.SelectedIndex].Text;

            // Validations
            if (UserManagement.UserExitsByName(newUser.UserName))
            {
                ErrorMessage.InnerText = "User already exists!";
                ErrorMessage.Visible = true;
            }

            CompanyUserManagement.CreateCompanyUser(currentCompany, newUser, role);

            // Reload page
            Response.Redirect(Request.RawUrl, false);
        }

        public void ShowUsers()
        {
            CompanyDTO currentCompany = AuthenticationManagement.GetCurrentUserCompany();

            DataTable companyUsers = CompanyUserManagement.GetCompanyUsersForDisplay(currentCompany.ID);

            CompanyUserListItems.DataSource = companyUsers;
            CompanyUserListItems.DataBind();
        }
    }
}
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
    public partial class RegisterForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorMessage.Visible = false;
        }

        protected void FormSubmit(object sender, EventArgs e)
        {
            CompanyDTO NewCompany = new CompanyDTO();
            NewCompany.CompanyName = CompanyName.Value;
            NewCompany.Email = CompanyEmail.Value;
            NewCompany.CIF = CIF.Value;

            UserDTO AdminUser = new UserDTO();
            AdminUser.UserName = User.Value;
            AdminUser.Email = UserEmail.Value;
            AdminUser.UserPassword = Cypher.HashStringWithSalt(UserPassword.Value);

            NewCompany.AdminUser = AdminUser;

            // Validation Checks
            if(AllFiedlsAreMandatoryCheck())
            {
                ErrorMessage.Visible = true;
                ErrorMessage.InnerText = "All fields are mandatory";

                return;
            }
            else if (CheckIfCompanyExists(NewCompany))
            {
                ErrorMessage.Visible = true;
                ErrorMessage.InnerText = "Company already exists!";

                return;
            }
            else if (CheckIfUserExits(AdminUser))
            {
                ErrorMessage.Visible = true;
                ErrorMessage.InnerText = "User already exists!";

                return;
            }

            CompanyManagment.CreateCompany(NewCompany);

            Response.Redirect("~/");
        }

        public bool CheckIfCompanyExists(CompanyDTO currentCompany)
        {
            bool existsByName = CompanyManagment.CompanyExitsByName(currentCompany.CompanyName);
            bool exitsByCIF = CompanyManagment.CompanyExitsByCIF(currentCompany.CIF);

            return existsByName == true || exitsByCIF == true;
        }

        public bool CheckIfUserExits(UserDTO currentUser)
        {
            bool existsByName = UserManagement.UserExitsByName(currentUser.UserName);

            return existsByName;
        }

        public bool AllFiedlsAreMandatoryCheck()
        {
            if (string.IsNullOrEmpty(CompanyName.Value)
                || string.IsNullOrEmpty(CompanyEmail.Value)
                || string.IsNullOrEmpty(CIF.Value)
                || string.IsNullOrEmpty(User.Value)
                || string.IsNullOrEmpty(UserEmail.Value)
                || string.IsNullOrEmpty(UserPassword.Value)
            )
            {
                return false;
            }

            return true;
        }
    }
}
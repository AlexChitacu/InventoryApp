using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventoryWebApp.Management;
using InventoryWebApp.Models;

namespace InventoryWebApp.Pages.Company
{
    public partial class Inventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthenticationManagement.IsCurrentUserAuthenticated())
                Response.Redirect("~/");

            ErrorMessage.Visible = false;

            DataTable product = GeneralManagement.GetProductsAll();
            DataTable depos = GeneralManagement.GetDeposAll();

            if (!IsPostBack)
            {
                // Populate Products Select
                ProductSelect.DataSource = product;
                ProductSelect.DataValueField = "ID";
                ProductSelect.DataTextField = "ProductName";

                ProductSelect.DataBind();

                // Populate Depos Select
                DepoSelect.DataSource = depos;
                DepoSelect.DataValueField = "ID";
                DepoSelect.DataTextField = "DepoName";

                DepoSelect.DataBind();
            }

            DisplayCurrentInventory();
        }

        public void AddInvetory(object sender, EventArgs e)
        {
            InventoryDTO inventory = new InventoryDTO();

            inventory.CompanyID = AuthenticationManagement.GetCurrentUserCompany().ID;
            inventory.ProductId = int.Parse(ProductSelect.Items[ProductSelect.SelectedIndex].Value);
            inventory.DepoId = int.Parse(DepoSelect.Items[DepoSelect.SelectedIndex].Value);
            inventory.Ammount = int.Parse(ProductAmount.Value);

            CompanyInventoryManagement.AddCompanyInventory(inventory);

            // Reload page
            Response.Redirect(Request.RawUrl, false);
        }

        public void DisplayCurrentInventory()
        {
            InventoryItems.DataSource = CompanyInventoryManagement.GetCompanyInvForDisplay(AuthenticationManagement.GetCurrentUserCompany().ID);
            InventoryItems.DataBind();

            InventoryUpdatePanel.Update();
        }
    }
}
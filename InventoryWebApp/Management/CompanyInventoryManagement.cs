using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryWebApp.Utils;
using System.Data;
using System.Data.SqlClient;
using InventoryWebApp.Models;

namespace InventoryWebApp.Management
{
    public static class CompanyInventoryManagement
    {
        public static DataTable GetCompanyInvForDisplay(int CompanyId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(AppSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("GetCompanyInvForDisplay", con) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.AddWithValue("@CompanyID", CompanyId);

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {                      
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public static void AddCompanyInventory(InventoryDTO inventory)
        {
            using (SqlConnection con = new SqlConnection(AppSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("AddCompanyInventory", con) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.AddWithValue("@CompanyId", inventory.CompanyID);
                    command.Parameters.AddWithValue("@ProductId", inventory.ProductId);
                    command.Parameters.AddWithValue("@DepoId", inventory.DepoId);
                    command.Parameters.AddWithValue("@Ammount", inventory.Ammount);

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
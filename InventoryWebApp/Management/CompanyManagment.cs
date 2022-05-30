using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using InventoryWebApp.Utils;
using System.Data;
using InventoryWebApp.Models;

namespace InventoryWebApp.Management
{
    public static class CompanyManagment
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CompanyName"></param>
        /// <returns></returns>
        public static bool CompanyExitsByName(string CompanyName)
        {
            bool companyExits = false;

            using (SqlConnection con = new SqlConnection(AppSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("GetCompanyByName", con) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.AddWithValue("@CompanyName", CompanyName);

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                            companyExits = true;
                    }
                }
            }

            return companyExits;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CIF"></param>
        /// <returns></returns>
        public static bool CompanyExitsByCIF(string CIF)
        {
            bool companyExits = false;

            using (SqlConnection con = new SqlConnection(AppSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("GetCompanyByCIF", con) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.AddWithValue("@CIF", CIF);

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                            companyExits = true;
                    }
                }
            }

            return companyExits;
        }

        public static void CreateCompany(CompanyDTO NewCompany)
        {
            using (SqlConnection con = new SqlConnection(AppSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("CreateCompany", con) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.AddWithValue("@CompanyName", NewCompany.CompanyName);
                    command.Parameters.AddWithValue("@CompanyEmail", NewCompany.Email);
                    command.Parameters.AddWithValue("@CIF", NewCompany.CIF);
                    command.Parameters.AddWithValue("@UserName", NewCompany.AdminUser.UserName);
                    command.Parameters.AddWithValue("@UserEmail", NewCompany.AdminUser.Email);
                    command.Parameters.AddWithValue("@UserPassword", NewCompany.AdminUser.UserPassword);

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }     
    }
}
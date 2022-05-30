using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using InventoryWebApp.Utils;

namespace InventoryWebApp.Management
{
    public static class GeneralManagement
    {
        #region Init

        #endregion

        #region Stored Procedures
        public static List<string> GetAllRoles()
        {
            List<string> roles = new List<string>();

            using (SqlConnection con = new SqlConnection(AppSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("GetRolesAll", con) { CommandType = CommandType.StoredProcedure })
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        foreach(var row in dt.AsEnumerable())
                        {
                            roles.Add((string) row["RoleName"]);
                        }
                    }
                }
            }

            return roles;
        }

        public static DataTable GetProductsAll()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(AppSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("GetProductsAll", con) { CommandType = CommandType.StoredProcedure })
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public static DataTable GetDeposAll()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(AppSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("GetDeposAll", con) { CommandType = CommandType.StoredProcedure })
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }
        #endregion
    }
}
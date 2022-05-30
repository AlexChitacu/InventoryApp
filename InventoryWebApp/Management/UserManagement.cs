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
    public static class UserManagement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool UserExitsByName(string UserName)
        {
            bool userExists = false;

            using (SqlConnection con = new SqlConnection(AppSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("GetUserByName", con) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.AddWithValue("@UserName", UserName);

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                            userExists = true;
                    }
                }
            }

            return userExists;
        }

        public static UserDTO GetUserByName(string UserName)
        {
            using (SqlConnection con = new SqlConnection(AppSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("GetUserByName", con) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.AddWithValue("@UserName", UserName);

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        DataRow row = dt.Rows[0];

                        return new UserDTO()
                        {
                            ID = (int) row["ID"],
                            Email = (string) row["Email"],
                            UserName = (string) row["UserName"],
                            UserPassword = (string) row["UserPassword"]
                        };
                    }
                }
            }
        }

        public static bool CheckIfUserExists(UserDTO existingUser)
        {
            bool userExists = false;

            using (SqlConnection con = new SqlConnection(AppSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("GetUserByCredentials", con) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.AddWithValue("@UserName", existingUser.UserName);
                    command.Parameters.AddWithValue("@UserPassword", existingUser.UserPassword);

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        if(dt.Rows.Count > 0)
                        {
                            userExists = true;
                        }
                    }
                }
            }

            return userExists;
        }

        public static CompanyDTO GetUserCompany(UserDTO currentUser)
        {
            CompanyDTO currentCompany = new CompanyDTO();

            using (SqlConnection con = new SqlConnection(AppSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("GetUserCompany", con) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.AddWithValue("@UserId", currentUser.ID);

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        DataRow dr = dt.Rows[0];

                        currentCompany.ID = (int)dr["ID"];
                        currentCompany.CompanyName = (string)dr["CompanyName"];
                        currentCompany.Email = (string)dr["Email"];
                        currentCompany.CIF = (string)dr["CIF"];
                    }
                }
            }

            return currentCompany;
        }
    }
}
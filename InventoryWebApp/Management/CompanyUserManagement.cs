using System;
using System.Data;
using InventoryWebApp.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using InventoryWebApp.Models;

namespace InventoryWebApp.Management
{
    public class CompanyUserManagement
    {
        public static void CreateCompanyUser(CompanyDTO UserCompany, UserDTO NewUser, string Role)
        {
            using (SqlConnection con = new SqlConnection(AppSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("CreateCompanyUser", con) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.AddWithValue("@CompanyId", UserCompany.ID);
                    command.Parameters.AddWithValue("@UserName", NewUser.UserName);
                    command.Parameters.AddWithValue("@UserEmail", NewUser.Email);
                    command.Parameters.AddWithValue("@UserPassword", NewUser.UserPassword);
                    command.Parameters.AddWithValue("@UserRole", Role);

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static DataTable GetCompanyUsersForDisplay(int companyId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(AppSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("GetCompanyUsersForDisplay", con) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.AddWithValue("@CompanyID", companyId);

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public static RoleDTO GetCompanyUserRole(int companyId, int UserId)
        {
            RoleDTO roleDTO = new RoleDTO();

            using (SqlConnection con = new SqlConnection(AppSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("GetCompanyUserRole", con) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.AddWithValue("@CompanyId", companyId);
                    command.Parameters.AddWithValue("@UserId", UserId);

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        roleDTO.ID = (int) dt.Rows[0]["ID"];
                        roleDTO.Name = (string)dt.Rows[0]["RoleName"];
                    }
                }
            }

            return roleDTO;
        }
    }
}
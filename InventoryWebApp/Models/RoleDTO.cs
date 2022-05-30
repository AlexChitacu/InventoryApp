using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryWebApp.Models
{
    public class RoleDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Roles Role { get { return (Roles) Enum.Parse(typeof(Roles), this.Name, true); } }
    }

    public enum Roles
    {
        Admin,
        Worker
    }
}
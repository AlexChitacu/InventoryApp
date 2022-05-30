using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryWebApp.Management;

namespace InventoryWebApp.Models
{
    public class UserDTO
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public string Email { get; set; }
    }
}
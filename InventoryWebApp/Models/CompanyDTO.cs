using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryWebApp.Models
{
    public class CompanyDTO
    {
        public int ID { get; set; }

        public string CompanyName { get; set; }

        public string Email { get; set; }

        public string CIF { get; set; }

        public UserDTO AdminUser { get; set; }
    }
}
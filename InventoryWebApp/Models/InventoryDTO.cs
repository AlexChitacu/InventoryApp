using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryWebApp.Models
{
    public class InventoryDTO
    {
        public int ID { get; set; }

        public int CompanyID { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int DepoId { get; set; }

        public string DepoName { get; set; }

        public int Ammount { get; set; }
    }
}
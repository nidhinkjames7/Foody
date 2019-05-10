using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace Foody.Models
{
    public class Shops
    {
        public string UserId { get; set; } /*Property*/
        public string OwnerName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Pincode { get; set; }
        public string Email { get; set; }
        public string RegistrationNo { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ShopName { get; set; }
        public string ShopType { get; set; }

    }
}
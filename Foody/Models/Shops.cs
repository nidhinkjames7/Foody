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
        public string ShopType { get; set; }
        public string UserId { get; set; } /*Property*/
        public string ShopName { get; set; }
        // public string OwnerName { get; set; }
        public string ShopAddress { get; set; }
        public string Phone { get; set; }
        public string Pincode { get; set; }
        public string Email { get; set; }
        public string RegistrationNo { get; set; }
    //    public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Status { get; set; }

    }
}
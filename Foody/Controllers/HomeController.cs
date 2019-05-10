using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Foody.Models;
using System.Data;
using MySql.Data.MySqlClient;

namespace Foody.Controllers
{
    public class HomeController : Controller
    {
        ConnectionModel obj = new ConnectionModel();
        

        //LOGIN


        [HttpGet]
        public ActionResult Login()
        {
            return View("../Home/LoginForm");
        }




       
        // SHOP REGISTRATION

        [HttpGet]
        public ActionResult RegisterShop()
        {
            return View("../Home/RegisterShop");
        }



        [HttpPost]

        public ActionResult RegisterShop(Shops shopobj)
        {
            DataTable dt = new DataTable();
            try
            {
                obj.InsertShop(shopobj);
            }
            catch
            {

            }
            return View();
        }


        //REGISTER SHOP ADMIN

        [HttpGet]
        public ActionResult RegisterShopAdmin()
        {
            return View("../Home/RegisterShopAdmin");
        }



        [HttpPost]

        public ActionResult RegisterShopAdmin(ShopAdmin shopadminobj)
        {  
            DataTable dt = new DataTable();
            try
            {
                obj.InsertShopAdmin(shopadminobj);
            }
            catch
            {

            }
            return View();
        }


        //SHOP ADMIN VIEW

        [HttpGet]

        public ActionResult ViewShopAdmin()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetShopAdmin();
                ViewData["data"] = dt;
            }
            catch
            {

            }
            return View("../Home/ViewShopAdmin");
        }



        //REMOVE SHOP ADMIN

        [HttpGet]

        public RedirectToRouteResult RemoveShopAdmin()
        {
            DataTable dt = new DataTable();
            try
            {
                int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                obj.RemoveShopAdmin(id);
                ViewData["data"] = dt;
            }
            catch (Exception e)
            {

            }
            return RedirectToAction("LoadShopAdminData");
        }
        [ActionName("LoadShopAdminData")]

        public ActionResult LoadShopAdminData()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetShopAdmin();
                ViewData["data"] = dt;
            }
            catch
            {

            }
            return View("../Home/ViewShopAdmin");
        }





        //SHOP VIEW

        [HttpGet]

        public ActionResult ViewShop()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetShop();
                ViewData["data"] = dt;
            }
            catch
            {

            }
            return View("../Home/ViewShop");
        }


        // REMOVE SHOP

        [HttpGet]

        public RedirectToRouteResult RemoveShop()
        {
            DataTable dt = new DataTable();
            try
            {
                int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                obj.RemoveShop(id);
                ViewData["data"] = dt;
            }
            catch (Exception e)
            {

            }
            return RedirectToAction("LoadShopData");
        }
        [ActionName("LoadShopData")]

        public ActionResult LoadShopData()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetShop();
                ViewData["data"] = dt;
            }
            catch
            {

            }
            return View("../Home/ViewShop");
        }




        public ActionResult Index()
        {
            return View("../Home/AdminHome");
        }



        //UPDATE SHOP


        public ActionResult UpdateShopDe()
        {
            DataTable dt = new DataTable();
            try
            {
                int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                obj.UpdateShop(id);
                ViewData["data"] = dt;
            }
            catch (Exception e)
            {

            }
            return View("../Home/UpdateShopDetails");
        }
        [ActionName("UpdateShopData")]

        public ActionResult UpdateShop()
        {
            DataTable dt = new DataTable();
            try
            {
                string shop_name = Request["shop_name"].ToString();
                string user_id = Request["user_id"].ToString();
                string owner_name = Request["owner_name"].ToString();
                string address = Request["address"].ToString();
                string pincode = Request["pincode"].ToString();
                string shop_type = Request["shop_type"].ToString();
                string mobile = Request["mobile"].ToString();
                string email = Request["email"].ToString();
                string registration_no = Request["registration_no"].ToString();
                string description = Request["description"].ToString();
                string logitude = Request["logitude"].ToString();
                string latitude = Request["latitude"].ToString();
                obj.UpdateShopData(shop_name, user_id, owner_name, address, pincode, shop_type, mobile, email, registration_no, description, logitude, latitude);
            }
            catch
            {

            }
            return View("../Home/UpdateShopDetails");
        }







        //DELIVERY BOY REGISTRATION



        [HttpGet]
        public ActionResult RegisterDeliveryBoy()
        {
            return View("../Home/RegisterDeliveryBoy");
        }


        [HttpPost]
        public ActionResult RegisterDeliveryBoy(DeliveryBoy boyobj)
        {
            DataTable dt = new DataTable();
            try
            {
                obj.InsertBoy(boyobj);
            }
            catch (Exception e)
            {

            }
            return View();
        }


        //DELIVERY BOY VIEW

        [HttpGet]

        public ActionResult ViewDeliveryBoy()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetDeliveryBoy();
                ViewData["data"] = dt;
            }
            catch
            {

            }
            return View("../Home/ViewDeliveryBoy");
        }


        //REMOVE DELIVERY BOY

        [HttpGet]

        public RedirectToRouteResult RemoveDeliveryBoy()
        {
            DataTable dt = new DataTable();
            try
            {
                int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                obj.RemoveDeliveryBoy(id);
                ViewData["data"] = dt;
            }
            catch (Exception e)
            {

            }
            return RedirectToAction("LoadDeliveryBoyData");
        }
        [ActionName("LoadDeliveryBoyData")]

        public ActionResult LoadDeliveryBoyData()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetDeliveryBoy();
                ViewData["data"] = dt;
            }
            catch
            {

            }
            return View("../Home/ViewDeliveryBoy");
        }






        //VIEW FOODY RATING

        [HttpGet]

        public ActionResult ViewFoodyRating()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetFoodyRating();
                ViewData["data"] = dt;
            }
            catch
            {

            }
            return View("../Home/ViewFoodyRating");
        }


        





        //VIEW FOODY REVIEW

        [HttpGet]

        public ActionResult ViewFoodyReview()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetFoodyReview();
                ViewData["data"] = dt;
            }
            catch
            {

            }
            return View("../Home/ViewFoodyReview");
        }



        // SEARCH SHOP


        [HttpGet]
        public ActionResult SearchShop(string ShopType)
        {
            DataTable dt = new DataTable();
            try
            {

                dt = obj.SelectShop(ShopType);
                Session["data"] = dt;

            }
            catch (Exception e)
            {

            }
            return View("../Home/SearchShop");
        }

        [HttpPost]
        public ActionResult Search(string ShopType)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.SelectShop(ShopType);
                ViewData["data"] = dt;
            }
            catch (Exception e)
            {

            }
            return View("../Home/SearchShop");
        }




        // IN-BUILT

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        //public ActionResult searching(string option, string search)
        //{
        //    if (option == "Type")
        //    {
        //        return View(night_food.shops.where(x => x.Type == search || search == null).ToList());
        //    }
        //    else if (option == "Name")
        //    {
        //        return View(night_food.shops.where(x => x.Name == search || search == null).ToList());
        //    }
        //}

    }
}
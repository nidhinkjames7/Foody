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
        public ActionResult RegisterShopHere()
        {
            DataTable dt = new DataTable();
            try
            {
        //        string ShopId = Request["shop_id"].ToString();
                string ShopType = Request["shop_type"].ToString();
                string UserId = Request["user_id"].ToString();
                string ShopName = Request["shop_name"].ToString();
                string ShopAddress = Request["shop_address"].ToString();
                string Phone = Request["phone"].ToString();
                string Pincode = Request["pincode"].ToString();
                string Email = Request["email"].ToString();
                string RegistrationNo =Request["registration_no"].ToString();
                string Latitude =Request["latitude"].ToString();
                string Longitude =Request["longitude"].ToString();
                string Status = Request["status"].ToString();
                obj.InsertShop(ShopType, UserId, ShopName,ShopAddress, Phone, Pincode, Email, RegistrationNo, Latitude, Longitude, Status);
            }
            catch
            {

            }
            return View("../Home/RegisterShop");
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
           //     dt = obj.GetShopType();
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

        [HttpGet]

        public ActionResult UpdateOneShop()
        {
            DataTable dt = new DataTable();
            try
            {
                int id = Convert.ToInt32(Request.QueryString["id"].ToString());
               dt= obj.UpdateShop(id);
                ViewData["data"] = dt;
            }
            catch (Exception e)
            {

            }
            return View("../Home/UpdateShopDetails");
        }


        [HttpPost]
        [ActionName("UserUpdateShopData")]

        
        public ActionResult UserUpdateShopData()
        {
            DataTable dt = new DataTable();
            try
            {
                string shop_id = Request["shop_id"].ToString();
                string shop_name = Request["shop_name"].ToString();
                string user_id = Request["user_id"].ToString();
             //   string owner_name = Request["owner_name"].ToString();
                string address = Request["shop_address"].ToString();
                string pincode = Request["pincode"].ToString();
                string shop_type = Request["shop_type"].ToString();
                string phone = Request["phone"].ToString();
                string email = Request["email"].ToString();
                string registration_no = Request["registration_no"].ToString();
            //    string description = Request["description"].ToString();
                string logitude = Request["longitude"].ToString();
                string latitude = Request["latitude"].ToString();
               // obj.UpdateShopData(shop_id,shop_name, user_id, owner_name, address, pincode, shop_type, mobile, email, registration_no, description, logitude, latitude);
                obj.UpdateShopDataHere(shop_id, shop_name, user_id, address, pincode, shop_type, phone, email, registration_no, logitude, latitude);
            }
            catch(Exception e)
            {

            }
            return RedirectToAction("ViewShop");
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
           //     obj.InsertBoy(boyobj);
                string UserId = Request["user_id"].ToString();
                string Name = Request["name"].ToString();
                string Address = Request["address"].ToString();
                string Phone = Request["phone"].ToString();
                string Email = Request["email"].ToString();
                obj.InsertBoy(UserId, Name, Address, Phone, Email);
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


        
        //VIEW DELIVERY BOY RATING


        [HttpGet]

        public ActionResult ViewDeliveryBoyRating()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetDeliveryBoyRating();
                ViewData["data"] = dt;
            }
            catch
            {

            }
            return View("../Home/ViewDeliveryBoyRating");
        }



        // VIEW SHOP RATING


        [HttpGet]

        public ActionResult ViewShopRating()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetShopRating();
                ViewData["data"] = dt;
            }
            catch
            {

            }
            return View("../Home/ViewShopRating");
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



        //VIEW DELIVERY BOY REVIEW

        [HttpGet]

        public ActionResult ViewDeliveryBoyReview()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetDeliveryBoyReview();
                ViewData["data"] = dt;
            }
            catch
            {

            }
            return View("../Home/ViewDeliveryBoyReview");
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


        [HttpPost]
        public ActionResult SearchShopForm(Shops shopobj,string Search,string ViewAll)
        {
            DataTable dt = new DataTable();
            try
            {
                if(Search=="Search")
                {
                    dt=obj.SearchShop(shopobj);
                    ViewData["data"] = dt;
                }
                else if(ViewAll=="ViewAll")
                {
                    dt = obj.GetShop();
                    ViewData["data"] = dt;
                }
            }
            catch(Exception e)
            {

            }
            return View("../Home/ViewShop");
        }

    }
}
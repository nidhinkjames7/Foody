using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace Foody.Models
{
    public class ConnectionModel
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;
        DataTable dt;

        public void MakeConnection()
        {
           string cnString = "server=lapis.co.in;database=lapisco_nightfoodapp;uid=lapisco_user;pwd=lapisuser@123";
            //string cnString = "server=localhost;database=night_food;uid=root;pwd=root";
            con = new MySqlConnection(cnString);
            con.Open();
        }

        public void InsertShop(string ShopType,string UserId,string ShopName,string ShopAddress,string Phone,string Pincode,string Email,string RegistrationNo,string Latitude,string Longitude,string Status)
        {
            try
            {
                MakeConnection();
            //    cmd = new MySqlCommand("INSERT INTO shops values(null,'"+shopobj.ShopName+"','"+shopobj.OwnerName+"','"+shopobj.Address+"','"+shopobj.Pincode+"','"+shopobj.Description+"','"+shopobj.Mobile+"','"+shopobj.Email+"','"+shopobj.RegistrationNo+"','"+shopobj.Latitude+"','"+shopobj.Longitude+"')",con);
           //     cmd = new MySqlCommand("INSERT INTO shops(shop_id,user_id,address,mobile,pincode,email,registration_no,description,owner_name,latitude,longitude,shop_name,shop_type)values(null,'"+shopobj.UserId+"','" + shopobj.Address + "','" + shopobj.Mobile + "','" + shopobj.Pincode + "','" + shopobj.Email + "','" + shopobj.RegistrationNo + "','" + shopobj.Description + "','" + shopobj.OwnerName + "','" + shopobj.Latitude + "','" + shopobj.Longitude + "','" + shopobj.ShopName + "','"+shopobj.ShopType+"')", con);

                //cmd = new MySqlCommand("INSERT INTO shops(shop_id,shop_name,shop_address,phone,email,registration_no,user_id,pincode,latitude,longitude,status)values(null,'" + shopobj.ShopName + "','" + shopobj.ShopAddress + "','" + shopobj.Phone + "','" + shopobj.Email + "','" + shopobj.RegistrationNo + "','" + shopobj.UserId + "','" + shopobj.Pincode + "','" + shopobj.Latitude + "','" + shopobj.Longitude + "','" + shopobj.Status + "')", con);

                cmd = new MySqlCommand("INSERT INTO shops(shop_id,shop_type,user_id,shop_name,shop_address,phone,pincode,email,registration_no,latitude,longitude,status) values(null,'" + ShopType + "','" + UserId + "','" + ShopName + "','" + ShopAddress + "','" + Phone + "','" + Pincode + "','" + Email + "','" + RegistrationNo + "','" + Latitude + "','" + Longitude + "','" + Status + "')", con);

                
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception e)
            {

            }
        }
        public DataTable GetShop()
        {
            dt = new DataTable();
            try
            {
                MakeConnection();
                cmd = new MySqlCommand("SELECT * FROM shops", con);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.Close();
            }
            catch(Exception e)
            {

            }
            return dt;
        }



        //public DataTable GetShopType()
        //{
        //    dt = new DataTable();
        //    try
        //    {
        //        MakeConnection();
        //        cmd = new MySqlCommand("SELECT DISTINCT FROM shops", con);
        //        reader = cmd.ExecuteReader();
        //        dt.Load(reader);
        //        con.Close();
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return dt;
        //}



        public void RemoveShop(int ShopId)
        {
            try
            {
                MakeConnection();
                cmd = new MySqlCommand("DELETE FROM shops where shop_id=" +ShopId+ "", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception e)
            {

            }
        }


        //UPDATE SHOP

        public DataTable UpdateShop(int ShopId)
        {
            dt = new DataTable();
            try
            {
                MakeConnection();
                cmd = new MySqlCommand("SELECT * FROM shops where shop_id="+ShopId+"", con);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.Close();
            }
            catch (Exception e)
            {

            }
            return dt;
        }

        public void UpdateShopDataHere(string shop_id,string shop_name,string user_id,string address,string pincode,string shop_type,string phone,string email,string registration_no,string logitude, string latitude)
        {
            try
            {
                MakeConnection();
          //    cmd=new MySqlCommand("UPDATE shops SET shop_name='1',user_id='1',owner_name='1',address='1',pincode='1',shop_type='1',mobile='1',email='1',registration_no='1',description='1',longitude='1',latitude='1' where shop_id='13'",con);
          //      cmd= new MySqlCommand("UPDATE shops SET shop_name='"+shop_name+"',user_id='"+user_id+"',owner_name='"+owner_name+"',address='"+address+"',pincode='"+pincode+"',shop_type='"+shop_type+"',mobile='"+mobile+"',email='"+email+"',registration_no='"+registration_no+"',description='"+description+"',longitude='"+longitude+"',latitude='"+latitude+"' where shop_id='"+Convert.ToInt32(shop_id)+"'",con);
                cmd = new MySqlCommand("UPDATE shops SET shop_name='" + shop_name + "',user_id='" + user_id + "',shop_address='" + address + "',pincode='" + pincode + "',shop_type='" + shop_type + "',phone='" + phone + "',email='" + email + "',registration_no='" + registration_no + "',longitude='" + logitude + "',latitude='" + latitude + "' where shop_id='" + Convert.ToInt32(shop_id) + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception e){

            }
        }





        //SHOP ADMIN



        public void InsertShopAdmin(ShopAdmin shopadminobj)
        {
            try
            {
                MakeConnection();
           //     cmd = new MySqlCommand("INSERT INTO shop_admin(shop_admin_id,admin_name,shop_name,owner_name,address,dob,mobile,email,photo)values(null,'" + shopadminobj.AdminName+ "','" + shopadminobj.ShopName + "','" + shopadminobj.OwnerName + "','" + shopadminobj.Address + "','" + shopadminobj.Dob + "','" + shopadminobj.Mobile + "','" + shopadminobj.Email + "','" + shopadminobj.Photo + "')", con);
                cmd = new MySqlCommand("INSERT INTO shop_admin values(null,'" + shopadminobj.AdminName + "','" + shopadminobj.ShopName + "','" + shopadminobj.OwnerName + "','" + shopadminobj.Address + "','" + shopadminobj.Dob + "','" + shopadminobj.Mobile + "','" + shopadminobj.Email + "','" + shopadminobj.Photo + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {

            }
        }


        //SHOP ADMIN VIEW

        public DataTable GetShopAdmin()
        {
            dt = new DataTable();
            try
            {
                MakeConnection();
                cmd = new MySqlCommand("SELECT * FROM shop_admin", con);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.Close();
            }
            catch (Exception e)
            {

            }
            return dt;
        }


        //SHOP ADMIN REMOVE

        public void RemoveShopAdmin(int AdminId)
        {
            try
            {
                MakeConnection();
                cmd = new MySqlCommand("DELETE FROM shop_admin where shop_admin_id=" + AdminId + "", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {

            }

        }



        //DELIVERY BOY

        public void InsertBoy(string UserId, string Name, string Address, string Phone,string Email)
        {
            try
            {
                MakeConnection();
             //   cmd = new MySqlCommand("INSERT INTO delivery_boy(boy_id,boy_name,boy_address,mobile,email,photo,pancard_image,pancard_no,pincode,dob)values(null,'" + boyobj.BoyName + "','" + boyobj.BoyAddress + "','" + boyobj.Phone + "','" + boyobj.Email + "','" + boyobj.Photo + "','" + boyobj.PancardImage + "','" + boyobj.PancardNo + "','" + boyobj.Pincode + "','" + boyobj.Dob + "')", con); 
             //   cmd = new MySqlCommand("INSERT INTO delivery_boy(deliveryboy_id,user_id,name,address,phone,email)values(null,'" + boyobj.UserId + "','" + boyobj.Name + "','" + boyobj.Address + "','"+boyobj.Phone+"','" + boyobj.Email + "')", con);
                cmd = new MySqlCommand("INSERT INTO delivery_boy(deliveryboy_id,user_id,name,address,phone,email)values(null,'" + UserId + "','" + Name + "','" + Address + "','" + Phone + "','" + Email + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception e)
            {

            }
        }

        public DataTable GetDeliveryBoy()
        {
            dt = new DataTable();
            try
            {
                MakeConnection();
                cmd = new MySqlCommand("SELECT * FROM delivery_boy", con);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.Close();
            }
            catch (Exception e)
            {

            }
            return dt;
        }


        public void RemoveDeliveryBoy(int DeliveryBoyId)
        {
            try
            {
                MakeConnection();
                cmd = new MySqlCommand("DELETE FROM delivery_boy where deliveryboy_id=" + DeliveryBoyId + "", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {

            }
        }


        // FOODY RATING

        public DataTable GetFoodyRating()
        {
            dt = new DataTable();
            try
            {
                MakeConnection();
                cmd = new MySqlCommand("SELECT * FROM rating_app", con);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.Close();
            }
            catch (Exception e)
            {

            }
            return dt;
        }



        // DELIVERY BOY RATING

        public DataTable GetDeliveryBoyRating()
        {
            dt = new DataTable();
            try
            {
                MakeConnection();
                cmd = new MySqlCommand("SELECT * FROM rating_delivery_boy", con);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.Close();
            }
            catch (Exception e)
            {

            }
            return dt;
        }




        //SHOP RATING


        public DataTable GetShopRating()
        {
            dt = new DataTable();
            try
            {
                MakeConnection();
                cmd = new MySqlCommand("SELECT * FROM rating_shop", con);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.Close();
            }
            catch (Exception e)
            {

            }
            return dt;
        }




        // FOODY REVIEWS

        public DataTable GetFoodyReview()
        {
            dt = new DataTable();
            try
            {
                MakeConnection();
                cmd = new MySqlCommand("SELECT * FROM review_app", con);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.Close();
            }
            catch (Exception e)
            {

            }
            return dt;
        }



        //DELIVERY BOY REVIEW


        public DataTable GetDeliveryBoyReview()
        {
            dt = new DataTable();
            try
            {
                MakeConnection();
                cmd = new MySqlCommand("SELECT * FROM review_deliveryboy", con);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.Close();
            }
            catch (Exception e)
            {

            }
            return dt;
        }



        // SHOP REVIEW


        public DataTable GetShopReview()
        {
            dt = new DataTable();
            try
            {
                MakeConnection();
                cmd = new MySqlCommand("SELECT * FROM review_shop", con);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.Close();
            }
            catch (Exception e)
            {

            }
            return dt;
        }



        public DataTable SelectShop(string type)
        {
            try
            {
                dt = new DataTable();
                cmd = new MySqlCommand("SELECT * FROM shops WHERE shop_type="+type+"",con);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.Close();
            }
            catch (Exception e)
            {

            }
            return dt;
        }

        public DataTable SearchShop(Shops shopobj)
        {
            DataTable dt = new DataTable();
            try
            {
                MakeConnection();
                cmd = new MySqlCommand("SELECT * FROM shops where shop_type='"+shopobj.ShopType+"'", con);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.Close();
            }
            catch(Exception e) 
            {

            }
            return dt;
        }

    }
}
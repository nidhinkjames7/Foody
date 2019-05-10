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
            string cnString = "server=localhost;database=night_food;uid=root;pwd=root";
            con = new MySqlConnection(cnString);
            con.Open();
        }

        public void InsertShop(Shops shopobj)
        {
            try
            {
                MakeConnection();
            //    cmd = new MySqlCommand("INSERT INTO shops values(null,'"+shopobj.ShopName+"','"+shopobj.OwnerName+"','"+shopobj.Address+"','"+shopobj.Pincode+"','"+shopobj.Description+"','"+shopobj.Mobile+"','"+shopobj.Email+"','"+shopobj.RegistrationNo+"','"+shopobj.Latitude+"','"+shopobj.Longitude+"')",con);
                cmd = new MySqlCommand("INSERT INTO shops(shop_id,user_id,address,mobile,pincode,email,registration_no,description,owner_name,latitude,longitude,shop_name,shop_type)values(null,'"+shopobj.UserId+"','" + shopobj.Address + "','" + shopobj.Mobile + "','" + shopobj.Pincode + "','" + shopobj.Email + "','" + shopobj.RegistrationNo + "','" + shopobj.Description + "','" + shopobj.OwnerName + "','" + shopobj.Latitude + "','" + shopobj.Longitude + "','" + shopobj.ShopName + "','"+shopobj.ShopType+"')", con);
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

        public void UpdateShopData(string shop_name,int user_id,string owner_name,string address,int pincode,string shop_type,int mobile,string email,string registration_no,string description,string logitude, string latitude)
        {
            try
            {
                MakeConnection();
                cmd= new MySqlCommand("UPDATE shops SET shop_name='"+shop_name+"',user_id='"+user_id+"',owner_name='"+owner_name+"',address='"+address+"',pincode='"+pincode+"','"+shop_type+"',mobile='"+mobile+"',email='"+email+"',registration_no='"+registration_no+"',description='"+description+"',logitude='"+logitude+"',latitude='"+latitude+"' ",con);
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

        public void InsertBoy(DeliveryBoy boyobj)
        {
            try
            {
                MakeConnection();
                cmd = new MySqlCommand("INSERT INTO delivery_boy(boy_id,boy_name,boy_address,mobile,email,photo,pancard_image,pancard_no,pincode,dob)values(null,'" + boyobj.BoyName + "','" + boyobj.BoyAddress + "','" + boyobj.Mobile + "','" + boyobj.Email + "','" + boyobj.Photo + "','" + boyobj.PancardImage + "','" + boyobj.PancardNo + "','" + boyobj.Pincode + "','" + boyobj.Dob + "')", con); 
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
                cmd = new MySqlCommand("DELETE FROM delivery_boy where boy_id=" + DeliveryBoyId + "", con);
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
                cmd = new MySqlCommand("SELECT * FROM foody_rating", con);
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
                cmd = new MySqlCommand("SELECT * FROM foody_review", con);
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

    }
}
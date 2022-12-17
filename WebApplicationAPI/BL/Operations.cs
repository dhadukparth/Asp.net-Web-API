using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebApplicationAPI.BL
{
    public class Operations
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataAdapter adr;

        public Operations()
        {
            string constr = ConfigurationManager.ConnectionStrings["conn"].ToString();
            con = new SqlConnection(constr);
        }


        public string newcontent(int number, string name, string address)
        {
            string result = "";
            try
            {
                con.Open();
                string insertquery = "insert into ContentBook (number, name, address) values(@number, @name, @address)";
                com = new SqlCommand(insertquery, con);
                com.Parameters.AddWithValue("@name", name);
                com.Parameters.AddWithValue("@number", number);
                com.Parameters.AddWithValue("@address", address);
                int ans = com.ExecuteNonQuery();
                if(ans == 1)
                {
                    result = "Saved SuccessFully";
                }
                else
                {
                    result = "Sorry! Not Record Saved.";
                }

            }
            catch (Exception ex)
            {
                throw(ex);
            }
            finally
            {
                con.Close();
            }
            return result;
        }


        public DataTable FetchAll()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                string query = "select id, name, number, address from ContentBook";
                adr = new SqlDataAdapter(query, con);
                dt = new DataTable();
                adr.Fill(dt);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                con.Close();
            }
            return dt;

        }


        public string editcontent(int id, int number, string name, string address)
        {
            string result = "";
            try
            {
                con.Open();
                string query = "update ContentBook set name=@name, address=@address, number=@number where id=@id";
                com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@name", name);
                com.Parameters.AddWithValue("@number", number);
                com.Parameters.AddWithValue("@address", address);
                int ans = com.ExecuteNonQuery();
                if(ans == 1)
                {
                    result = "Update SuccessFully";
                }
                else
                {
                    result = "Sorry! This Record Is not Updated.";
                }
            }
            catch (Exception ex)
            {
                throw(ex);
            }
            finally
            {
                con.Close();
            }
            return result;
        }


        public string removecontent(int number)
        {
            string result = "";
            try
            {
                con.Open();
                string query = "delete from ContentBook where number = @number";
                com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("@number", number);
                int ans = com.ExecuteNonQuery();
                if (ans == 1)
                {
                    result = "Delete SuccessFully";
                }
                else
                {
                    result = "Sorry!, This Number Is Not Deleted, Please Check Your Number.";
                }
            }
            catch (Exception ex)
            {
                throw(ex);
            }
            finally
            {
                con.Close();
            }
            return result;
        }
    }
}

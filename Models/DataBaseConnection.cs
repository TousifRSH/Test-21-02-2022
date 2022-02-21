using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;

namespace BoutiqueShopTest.Models
{
    public class DataBaseConnection
    {
        static string CONNECTIONDB = @"Data Source=RILPT185;Initial Catalog=boutiqueShow;User ID = sa;Password=sa123";

        public List<ShopEntity> GetAllDetails()
        {
            List<ShopEntity> list = new List<ShopEntity>();
            using (SqlConnection SQLCON = new SqlConnection(CONNECTIONDB))
            {
                try
                {
                    SQLCON.Open();
                    SqlCommand Cmd = SQLCON.CreateCommand();
                    Cmd.CommandText = "Select* from shop";
                    var reader = Cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        if (reader == null)
                            throw new Exception("plase Eneter data into data base Shop");
                        else
                        {
                            var shop = new ShopEntity();
                            shop.ShopID = Convert.ToInt32(reader[0]);
                            shop.DressName = reader[1].ToString();
                            shop.Price = Convert.ToDouble(reader[2]);
                            shop.Color = reader[3].ToString();
                            list.Add(shop);
                        }

                    }
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);

                }
            }
            return list;
        }

        public void AddNewDress(ShopEntity newShop)
        {
            using (SqlConnection Conn = new SqlConnection(CONNECTIONDB))
            {

                var query = "insert into Shop values(@Dressname,@Price,@Color)";

                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@Dressname", newShop.DressName);
                cmd.Parameters.AddWithValue("@Price", newShop.Price);
                cmd.Parameters.AddWithValue("@Color", newShop.Color);

                try
                {
                    Conn.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected == 0)
                        throw new Exception("No Banks are Added");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

        }


        public ShopEntity FindDress(int id)
        {

            using (SqlConnection data = new SqlConnection(CONNECTIONDB))
            {
                var Show = new ShopEntity();
                try
                {
                    data.Open();
                    SqlCommand cmd = data.CreateCommand();
                    cmd.CommandText = "select* from Shop where ShopID= " + id;
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        Show.ShopID = Convert.ToInt32(reader[0]);
                        Show.DressName = reader[1].ToString();
                        Show.Price = Convert.ToDouble(reader[2]);
                        Show.Color = reader[3].ToString();

                    }
                    else
                    {
                        throw new Exception($"No Shop found of {id}");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                return Show;
            }
        }

  
        public void UpdateDress(ShopEntity shop)
        {

            using (SqlConnection con = new SqlConnection(CONNECTIONDB))
            {
                var query = $"update Shop set dressname='{shop.DressName}',price={shop.Price},color='{shop.Color}', where shopID= {shop.ShopID}";
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new Exception("No Data found to upadte");
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

        }



        public void DeleteDress(int id)
        {
            using (SqlConnection Conn = new SqlConnection(CONNECTIONDB))
            {
                var Query = "delete from shop where ShopID=" + id;
                SqlCommand cmd = new SqlCommand(Query, Conn);

                try
                {
                    Conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


    }
}

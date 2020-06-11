using MySql.Data.MySqlClient;
using NoSQL_Yarik.Entitys;
using NoSQL_Yarik.Entytis;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQL_Yarik.DataBase
{
    public class DBManager
    {
        public static List<Gun> SelectGuns(MySqlConnection conn)
        {
            conn.Open();
            string sql = $"Select * from Gun limit 100";

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = conn,
                CommandText = sql
            };
            List<Gun> Guns = new List<Gun>();
            
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        Gun gun = new Gun();
                        gun.IdProduct = int.Parse(reader.GetString(0));
                        gun.Name = reader.GetString(1);
                        gun.Price = int.Parse(reader.GetString(2));
                        gun.Decription = reader.GetString(3);
                        gun.Quantity = int.Parse(reader.GetString(4));
                        gun.fk_Id_Category = int.Parse(reader.GetString(5));
                        gun.fk_Id_License= int.Parse(reader.GetString(6));
                        gun.fk_Id_Purveyer = int.Parse(reader.GetString(7));
                        Guns.Add(gun);
                    }
                }
            }
            conn.Close();
            return Guns;

        }

        public static Gun SelectGun(MySqlConnection conn, int id)
        {
            conn.Open();
            string sql = $"Select * from Gun where id_Product = {id}";

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = conn,
                CommandText = sql
            };
            Gun gun = new Gun();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        
                        gun.IdProduct = int.Parse(reader.GetString(0));
                        gun.Name = reader.GetString(1);
                        gun.Price = int.Parse(reader.GetString(2));
                        gun.Decription = reader.GetString(3);
                        gun.Quantity = int.Parse(reader.GetString(4));
                        gun.fk_Id_Category = int.Parse(reader.GetString(5));
                        gun.fk_Id_License = int.Parse(reader.GetString(6));
                        gun.fk_Id_Purveyer = int.Parse(reader.GetString(7));
                    }
                }
            }
            conn.Close();
            return gun;

        }

        public static List<Order> SelectOrders(MySqlConnection conn)
        {
            conn.Open();
            string sql = $"Select * from pojiloy_mista.order order by pojiloy_mista.order.id_Order desc limit 10";

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = conn,
                CommandText = sql
            };
            List<Order> orders = new List<Order>();

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        Order order = new Order();
                        try
                        {
                            order.IdOrder = int.Parse(reader.GetString(0));
                            order.Data = reader.GetString(1);
                            order.Adress = reader.GetString(2);
                            order.Started = bool.Parse(reader.GetString(3)); //== 1 ? true:false;
                            order.Completed = bool.Parse(reader.GetString(4)); //== 1 ? true : false;
                            order.fk_Id_User = int.Parse(reader.GetString(5));
                            orders.Add(order);
                        }
                        catch { }
                    }
                }
            }
            conn.Close();
            return orders;

        }

        public static void InsertOrder(MySqlConnection conn, Order order)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            
            long id = cmd.LastInsertedId;
            string sql = $"INSERT INTO `pojiloy_mista`.`order`"+
            "(`id_Order`,"+
            "`Data`," +
            "`Adress`," +
            "`Started`," +
            "`Completed`," +
            "`fk_id_User`)" +
            "VALUES" +
            $"({id}," +
            $"'{order.Data}'," +
            $"'{order.Adress}'," +
            $"{ order.Started }," +
            $"{ order.Completed }," +
            $"{ order.fk_Id_User }); ";

            cmd.Connection = conn;
            cmd.CommandText = sql;

            int rowCount = cmd.ExecuteNonQuery();         
            string result = "Обновлено строк = " + rowCount;
            conn.Close();
        }

        public static void UpdateGun(MySqlConnection conn, Gun gun)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();

            long id = cmd.LastInsertedId;
            string sql = $"UPDATE `pojiloy_mista`.`gun`"+
"SET"+
$"`Name` = '{ gun.Name }'," +
$"`Price` = { gun.Price }," +
$"`Descriprion` = '{ gun.Decription }'," +
$"`Quantity` = { gun.Quantity }," +
$"`fk_id_Category` = { gun.fk_Id_Category }," +
$"`fk_id_License` = { gun.fk_Id_License }," +
$"`fk_id_Purveyor` = { gun.fk_Id_Purveyer }" +
$" WHERE `id_Product` = { gun.IdProduct}; ";

            cmd.Connection = conn;
            cmd.CommandText = sql;

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void DeleteGun(MySqlConnection conn, int id)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            string sql = $"delete from pojiloy_mista.`order` where id_Order = {id};";

            cmd.Connection = conn;
            cmd.CommandText = sql;

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}

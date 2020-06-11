using MySql.Data.MySqlClient;
using NoSQL_Yarik.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQL_Yarik.DataBase
{
    public class OrderRepository : IRepository<Order>
    {
        private MySqlConnection conn;

        public OrderRepository()
        {
            conn = DBUtils.GetDBConnection();
        }

        public void Create(Order order)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();

            long id = cmd.LastInsertedId;
            string sql = $"INSERT INTO `pojiloy_mista`.`order`" +
            "(`id_Order`," +
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
            conn.Close();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> Find(IEnumerable<int> inds)
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

        public Order Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Order item)
        {
            throw new NotImplementedException();
        }
    }
}

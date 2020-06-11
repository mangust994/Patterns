using MySql.Data.MySqlClient;
using NoSQL_Yarik.Entytis;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQL_Yarik.DataBase
{
    public class GunRepository : IRepository<Gun>
    {
        private MySqlConnection conn;

        public GunRepository()
        {
            conn = DBUtils.GetDBConnection();
        }

        public void Create(Gun item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            string sql = $"delete from pojiloy_mista.`order` where id_Order = {id};";

            cmd.Connection = conn;
            cmd.CommandText = sql;

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public IEnumerable<Gun> Find(IEnumerable<int> inds)
        {
            conn.Open();
            string sql = $"Select * from Gun limit 100";

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = conn,
                CommandText = sql
            };
            List<GunBuilder> Guns = new List<GunBuilder>();
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
                        gun.fk_Id_License = int.Parse(reader.GetString(6));
                        gun.fk_Id_Purveyer = int.Parse(reader.GetString(7));
                        Guns.Add(new GunBuilder(gun));
                    }
                }
            }
            conn.Close();
            List<Gun> guns = new List<Gun>();
            Guns.ForEach(gun => guns.Add(gun.GetResult()));
            return guns;
        }

        public Gun Get(int id)
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

        public void Update(Gun gun)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();

            long id = cmd.LastInsertedId;
            string sql = $"UPDATE `pojiloy_mista`.`gun`" +
            "SET" +
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
    }
}

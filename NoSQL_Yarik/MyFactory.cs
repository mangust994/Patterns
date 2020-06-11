using NoSQL_Yarik.DataBase;
using NoSQL_Yarik.Entitys;
using NoSQL_Yarik.Entytis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQL_Yarik
{
    public class MyFactory
    {
        public static IRepository<Order> ReturnOrderRepository()
        {
            return new OrderRepository();
        }

        public static IRepository<Gun> ReturnGunRepository()
        {
            return new GunRepository();
        }
    }
}

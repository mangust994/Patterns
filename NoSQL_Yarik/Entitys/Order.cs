using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQL_Yarik.Entitys
{
    public class Order
    {
        public int IdOrder { get; set; }

        public string Data { get; set; }

        public string Adress { get; set; }

        public bool Started { get; set; }

        public bool Completed { get; set; }

        public int fk_Id_User { get; set; }
    }
}

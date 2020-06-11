using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQL_Yarik.Entytis
{
    public class Gun
    {
        public int IdProduct { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Decription { get; set; }

        public int Quantity { get; set; }

        public int fk_Id_Category { get; set; }

        public int fk_Id_License { get; set; }

        public int fk_Id_Purveyer { get; set; }

        public object Clone()
        {
            return new Gun
            {
                IdProduct = IdProduct,
                Name = Name,
                Price = Price,
                Decription = Decription,
                Quantity = Quantity,
                fk_Id_Category = fk_Id_Category,
                fk_Id_License = fk_Id_License,
                fk_Id_Purveyer = fk_Id_Purveyer
            };
        }

        public override string ToString()
        {
            string result = "";
            result += "idUser: " + this.IdProduct + "\n";
            result += "VkId: " + this.Name + "\n";
            result += "Nick: " + this.Price + "\n";
            result += "Attitude: " + this.Decription + "\n";
            result += "Money: " + this.Quantity + "\n";
            result += "Donate: " + this.fk_Id_Category + "\n";
            result += "TotalDonate: " + this.fk_Id_License + "\n";
            result += "LastDateActivity: " + this.fk_Id_Purveyer + "\n";
            return base.ToString();
        }
    }
}

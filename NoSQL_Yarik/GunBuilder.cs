using NoSQL_Yarik.Entytis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQL_Yarik
{
    public class GunBuilder:IBuilder<Gun>
    {
        Gun gun;

        public GunBuilder(Gun gun)
        {
            this.gun = gun;
        }

        public Gun GetResult()
        {
            if (gun == null)
                return new Gun();
            return gun;
        }

        public string AddEpichMack(string epichmack)
        {
            if (epichmack == null)
                return "Всмысле ты не купил мне эпичмак?";
            else
                return
                    "Оооо єпичмаак";
        }
    }
}

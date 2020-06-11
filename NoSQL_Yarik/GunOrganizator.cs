using NoSQL_Yarik.DataBase;
using NoSQL_Yarik.Entytis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQL_Yarik
{
    public class GunOrganizator
    {
        private IRepository<Gun> gunRepo = MyFactory.ReturnGunRepository();
        private Gun gun;

        public GunOrganizator(Gun gun)
        {
            this.gun = gun;
        }

        public Gun SaveState()
        {
            gunRepo.Update(gun);
            return (Gun)gun.Clone();
        }

        public void RestoreState(Gun gun)
        {
            this.gun = (Gun)gun.Clone();
        }
    }
}

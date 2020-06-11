using MySql.Data.MySqlClient;
using NoSQL_Yarik.DataBase;
using NoSQL_Yarik.Entytis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQL_Yarik
{
    public class GunObservable : IObservable
    {
        Gun gun;
        private IRepository<Gun> userRepo = MyFactory.ReturnGunRepository();

        List<IObserver> observers;
        public GunObservable()
        {
            observers = new List<IObserver>();
            gun = new Gun();
        }

        public GunObservable(Gun gun)
        {
            observers = new List<IObserver>();
            this.gun = gun;
        }

        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyUpdateObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(gun);
            }
        }

        public void NotifyCreateObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(gun);
            }
        }

        public void NotifyDeleteObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Delete(gun);
            }
        }

        public void ChangeModel(Gun gun)
        {
            userRepo.Update(gun);
            this.gun = gun;
            NotifyUpdateObservers();
        }

        public void CreateModel(Gun gun)
        {
            userRepo.Create(gun);
            this.gun = gun;
            NotifyCreateObservers();
        }

        public void DeleteModel(int id)
        {
            userRepo.Delete(id);
            NotifyDeleteObservers();
        }
    }
}

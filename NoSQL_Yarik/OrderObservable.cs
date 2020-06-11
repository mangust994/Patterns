using NoSQL_Yarik.DataBase;
using NoSQL_Yarik.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQL_Yarik
{
    public class OrderObservable : IObservable
    {
        Order order;
        private IRepository<Order> userRepo = MyFactory.ReturnOrderRepository();

        List<IObserver> observers;
        public OrderObservable()
        {
            observers = new List<IObserver>();
            order = new Order();
        }

        public OrderObservable(Order order)
        {
            observers = new List<IObserver>();
            this.order = order;
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
                o.Update(order);
            }
        }

        public void NotifyCreateObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(order);
            }
        }

        public void NotifyDeleteObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Delete(order);
            }
        }

        public void ChangeModel(Order order)
        {
            userRepo.Update(order);
            this.order = order;
            NotifyUpdateObservers();
        }

        public void CreateModel(Order order)
        {
            userRepo.Create(order);
            this.order = order;
            NotifyCreateObservers();
        }

        public void DeleteModel(int id)
        {
            userRepo.Delete(id);
            NotifyCreateObservers();
        }
    }
}

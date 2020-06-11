using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQL_Yarik.DataBase
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> Find(IEnumerable<int> inds);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}

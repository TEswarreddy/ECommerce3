using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce3.DataLayer.Repositories
{
    internal interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> GetByName(string name);

        T Add(T entity);
        T Update(T entity);
        bool Delete(int id);
    }
}

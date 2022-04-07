using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageOO.DAL.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        T GetOne(int id);

        IEnumerable<T> GetAll();

        bool Add(T Model);
        bool Update(T Model);
        bool Delete(int id);
    }
}

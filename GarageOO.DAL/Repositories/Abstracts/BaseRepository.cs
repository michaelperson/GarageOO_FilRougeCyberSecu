using GarageOO.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageOO.DAL.Repositories.Abstracts
{
    public abstract class BaseRepository<T> : IRepository<T>
        where T : class
    {
        protected readonly TfGarage _db;
        public BaseRepository(string ConnectionString)
        {
            _db = new TfGarage(ConnectionString);
        }

        public abstract T GetOne(int id);
        public abstract IEnumerable<T> GetAll();

        public abstract bool Add(T Model);

        public abstract bool Update(T Model);

        public abstract bool Delete(int id);
    }
}

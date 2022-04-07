using GarageOO.DAL.Entities;
using GarageOO.DAL.Repositories.Abstracts;
using GarageOO.DAL.Repositories.Interface;
using GarageOO.DAL.Repositories.Mappers;
using GarageOO.Models.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageOO.DAL.Repositories
{
    public class MecanicienRepository : BaseRepository<Mecanicien>, IMecanicienRepository
    {
        public MecanicienRepository(string ConnectionString) : base(ConnectionString)
        {
        }

        public override bool Add(Mecanicien Model)
        {             

            try
            {
                _db.Mecanos.Add(Model.ToEntity());
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException Dbex)
            {
                return false;
                
            }
        }

        public override bool Delete(int id)
        {
            try
            {
                _db.Mecanos.Remove(_db.Mecanos.Find(id));
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException dbex)
            {
                return false;

            }
        }

        public override IEnumerable<Mecanicien> GetAll()
        {
            return _db.Mecanos.Select(m => m.ToModel());
        }

        public override Mecanicien GetOne(int id)
        {
            MecanicienEntity FromDb = _db.Mecanos.Find(id);
            if (FromDb != null)
            {
               
                return FromDb.ToModel();

            }
            return null;
        }

        public override bool Update(Mecanicien Model)
        {
            MecanicienEntity Ve = _db.Mecanos.Find(Model.Id);
            Ve.Nom = Model.Nom;
            Ve.Expertise = Model.ExpertisEnNbSiege;

             
            try
            {
                if (_db.Entry<MecanicienEntity>(Ve).State == EntityState.Detached)
                {
                    _db.Entry<MecanicienEntity>(Ve).State = EntityState.Modified;
                }


                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException dbex)
            {
                return false;

            }
        }
    }
}

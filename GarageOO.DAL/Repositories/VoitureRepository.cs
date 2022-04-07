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
    public class VoitureRepository : BaseRepository<Voiture>, IVoitureRepository
    {
        

        public VoitureRepository(string ConnectionString) : base(ConnectionString)
        {
            
        }

        public override Voiture GetOne(int id)
        {
            VoitureEntity FromDb = _db.Voitures.Find(id);
            if(FromDb!=null)
            {
                //Mapping
                //return new Voiture(FromDb.Plaque, FromDb.Marque, FromDb.Couleur, FromDb.NbRoues,
                //    FromDb.NbPortes, FromDb.NbSiege);
                return FromDb.ToModel();
                 
            }
            return null;
        }
        public override IEnumerable<Voiture> GetAll()
        {
            return _db.Voitures.Select(m => m.ToModel());
        }

        public override bool Add(Voiture voiture)
        {
            //Mapping
            //VoitureEntity ToInsert = new VoitureEntity()
            //{
            //    CapaciteCoffre = voiture.CapaciteCoffre,
            //    Couleur = voiture.Couleur,
            //    Marque = voiture.Marque,
            //    NbPortes = voiture.NbPortes,
            //    NbRoues = voiture.NbRoues,
            //    Plaque = voiture.Plaque,
            //    NbSiege = voiture.NbSiege
            //};
            //_db.Voitures.Add(ToInsert);
            VoitureEntity toInsert = voiture.ToEntity();
            _db.Voitures.Add(toInsert);

            try
            {
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException  dbex)
            {
                _db.Voitures.Remove(toInsert);
                return false;
            }


        }

        public override bool Update(Voiture voiture)
        {
            VoitureEntity Ve = _db.Voitures.Find(voiture.Id);
            Ve.CapaciteCoffre = voiture.CapaciteCoffre;
            Ve.Couleur = voiture.Couleur;
            Ve.Marque = voiture.Marque;
            Ve.NbPortes = voiture.NbPortes;
            Ve.NbRoues = voiture.NbRoues;
            Ve.Plaque = voiture.Plaque;
            Ve.NbSiege = voiture.NbSiege;

          //VoitureEntity Ve =  voiture.ToEntity();
            try
            {
                if( _db.Entry<VoitureEntity>(Ve).State == EntityState.Detached)
                {
                    _db.Entry<VoitureEntity>(Ve).State = EntityState.Modified;
                }
                
               
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException dbex)
            {
                return false;
                
            }
        }

        public override bool Delete(int id)
        {
            try
            {
                _db.Voitures.Remove(_db.Voitures.Find(id));
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

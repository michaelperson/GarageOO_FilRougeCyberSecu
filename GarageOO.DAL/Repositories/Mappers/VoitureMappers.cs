using GarageOO.DAL.Entities;
using GarageOO.Models.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageOO.DAL.Repositories.Mappers
{
    public static class VoitureMappers  
    {
        public static Voiture ToModel(this VoitureEntity Entity)
        {
            Voiture voiture= new Voiture(Entity.Plaque, Entity.Marque, Entity.Couleur, Entity.NbRoues,
                     Entity.NbPortes, Entity.NbSiege);
            voiture.Id=Entity.Id;
            voiture.CapaciteCoffre = Entity.CapaciteCoffre;
            return voiture;
        }

        public static VoitureEntity ToEntity(this Voiture Model)
        {
            return   new VoitureEntity()
            { 
                Id=Model.Id,
                CapaciteCoffre = Model.CapaciteCoffre,
                Couleur = Model.Couleur,
                Marque = Model.Marque,
                NbPortes = Model.NbPortes,
                NbRoues = Model.NbRoues,
                Plaque = Model.Plaque,
                NbSiege = Model.NbSiege
            };
        }
    }
}

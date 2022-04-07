using GarageOO.DAL.Entities;
using GarageOO.Models.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageOO.DAL.Repositories.Mappers
{
    public static class MecanicienMappers  
    {
        public static Mecanicien ToModel(this MecanicienEntity Entity)
        {
            Mecanicien Mecanicien=  new Mecanicien(Entity.Nom)
            {
                ExpertisEnNbSiege = Entity.Expertise 
            }; 
            Mecanicien.Id=Entity.Id;
            return Mecanicien;
        }

        public static MecanicienEntity ToEntity(this Mecanicien Model)
        {
            return new MecanicienEntity()
            {
                Expertise = Model.ExpertisEnNbSiege,

                Nom = Model.Nom,
                Tarif = Model.Tarif,
                Id = Model.Id

            };
        }
    }
}

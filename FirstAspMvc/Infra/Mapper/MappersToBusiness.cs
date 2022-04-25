using FirstAspMvc.Models;
using FirstAspMvc.Models.Forms;
using GarageOO.Models.Concretes;

namespace FirstAspMvc.Infra.Mapper
{
    public static class MappersToBusiness
    {
        /*Remarque : je pourrais utiliser auto-mapper*/
        /****Voiture & ViewModel****/

        public static Voiture ToBusiness(this VoitureCreateViewModel model)
        {
            Voiture v= new Voiture(model.Plaque, model.Marque, model.Couleur, model.NbRoues, model.NbPortes, model.NbSiege);
            v.CapaciteCoffre = model.CapaciteCoffre;
            v.Id = model.Id;
            return v;
        }

        public static VoitureViewModel ToViewModel(this Voiture model)
        {
            return new VoitureViewModel()
            {
                Plaque = model.Plaque,
                Marque = model.Marque,
                Couleur = model.Couleur,
                NbRoues = model.NbRoues,
                 
                NbSiege = model.NbSiege,
                CapaciteCoffre = model.CapaciteCoffre,
                 Id= model.Id
                

            };
        }

        public static VoitureCreateViewModel ToCreateViewModel(this Voiture model)
        {
            return new VoitureCreateViewModel()
            {
                Plaque = model.Plaque,
                Marque = model.Marque,
                Couleur = model.Couleur,
                NbRoues = model.NbRoues,
                NbPortes = model.NbPortes,
                NbSiege = model.NbSiege,
                CapaciteCoffre = model.CapaciteCoffre,
                Id = model.Id


            };
        }
    }
}

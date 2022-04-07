using GarageOO.Models.Concretes;
using GarageOO.Models.Enumerations;
using GarageOO.Models.Interfaces;
using System.Collections.Generic;

namespace GarageOO.Models.Interfaces
{
    public interface IGarage
    {
        List<IMecano> Mecaniciens { get; set; }
        string Nom { get; set; }
        Dictionary<EAction, double> Tarifs { get; }

        //event DelEmplacement PlaceTrouvee; ==> Entraine l'ajout d'une propriété event
        // avec add et remove ==> https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-implement-custom-event-accessors
        double CalculPrix(Dictionary<EAction, bool> travail, IMecano responsable);
        void StockageVehicule(IVehicule vehicule);
    }
}
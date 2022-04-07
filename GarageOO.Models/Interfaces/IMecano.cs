using GarageOO.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageOO.Models.Interfaces
{
    /// <summary>
    /// Interface permettant de définir un mécano
    /// </summary>
    public interface IMecano
    {
        //const double PRIX2SIEGES = 90.50;
        //const double PRIX4SIEGES = 48.23;

        double Tarif { get; }

        /// <summary>
        /// Nom du mécano...Seul la récupération est obligatoire
        /// </summary>
        string Nom { get; }
        /// <summary>
        /// Niveau d'expertise du mécano
        /// </summary>
        int ExpertisEnNbSiege { get; set; }

        /// <summary>
        /// Méthode permettant de diagnostiquer le véhicule 
        /// </summary>
        /// <param name="vehicule">Véhicule a prendre en charge</param>
        /// <param name="operations">Les opérations a effectuer sur le véhicule (OUT)</param>
        /// <returns>True si la prise en charge peut être faite par le mécano</returns>
        bool PrendreEnCharge(IVoiture vehicule,out Dictionary<EAction, bool> operations);
        /// <summary>
        /// Permet de répare le véhicule
        /// </summary>
        /// <param name="vehicules">LE véhicule a réparer</param>
        /// <param name="operations">Les opérations effectuées sur le véhicule</param>
        /// <returns>True si les réparations ont été faites</returns>
        bool Reparation(IVoiture vehicules, Dictionary<EAction, bool> operations);
    }
}

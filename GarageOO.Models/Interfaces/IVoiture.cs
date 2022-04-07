using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageOO.Models.Interfaces
{
    /// <summary>
    /// Interface définissant le concept de voiture pour notre business
    /// </summary>
    public interface IVoiture : IVehicule
    {
        /*Propriétés*/
        /// <summary>
        /// Nombre de portes de notre voiture
        /// </summary>
        int NbPortes { get; }
        /// <summary>
        /// Capacité du coffre en litre
        /// </summary>
        double CapaciteCoffre { get; set; }
        /// <summary>
        /// Nombre de siège disponible
        /// </summary>
        int NbSiege { get; }
        /*Méthodes*/
    }
}

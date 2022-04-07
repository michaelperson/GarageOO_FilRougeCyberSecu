using GarageOO.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageOO.Models.Interfaces
{
    /// <summary>
    /// Interface définissant ce qu'est un véhicule pour notre business
    /// </summary>
    public interface IVehicule
    {
        /*Propriétés*/
        /// <summary>
        /// Numéro de plaque devant respecter le format Européen
        /// Sept caractères (un indice, trois lettres, trois chiffres).
        /// </summary>
        string Plaque { get;} //Seul la récupération du numéro de plaque est obligatoire
        /// <summary>
        /// Marque de la voiture
        /// </summary>
        string Marque { get;} //Seul la récupération de la marque est obligatoire
        /// <summary>
        /// Couleur de la voiture
        /// </summary>
        string Couleur { get;}// Seul la récupération de la couleur est obligatoire
       /// <summary>
       /// Nombre de roues pour la voiture
       /// </summary>
        int NbRoues { get; } //Seul la récupération du nombre de roues est obligatoire
        /*Méthodes*/
        /// <summary>
        /// Méthode permettant d'obtenir les points, opérations a effectuer sur le véhicule
        /// </summary>
        /// <returns>Un dictionnaire contenant la liste des points de contrôle associé a un état (true => effectué, False==> à faire) </returns>
        public Dictionary<EAction, bool> Inspecter();

    }
}

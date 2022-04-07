using GarageOO.Models.Enumerations;
using GarageOO.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageOO.Models.Abstracts
{
    /// <summary>
    /// Classe abstraite permettant de regrouper les caractéristiques
    /// communes des véhicules
    /// </summary>
    public abstract class Vehicule : IVehicule
    {
        /// <summary>
        /// Propriété ajoutée pour permettre le recherche dans la DB
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// La variable _plaque est en readonly, obligeant l'affectation
        /// de valeur uniquement dans le constructeur
        /// </summary>
        private readonly string _plaque;
        /// <summary>
        /// Propriété permettant d'atteindre la valeur de la plaque
        /// (implémentation de l'interface <see cref="IVehicule"/>
        /// </summary>
        public string Plaque  { get { return _plaque; } }

        /// <summary>
        /// Propriété permettant d'obtenir la marque du véhicule
        /// (implémentation de l'interface <see cref="IVehicule"/>
        /// </summary>
        public string Marque { get; }
        /// <summary>
        /// Propriété permettant d'obtenir la couleur du véhicule
        /// (implémentation de l'interface <see cref="IVehicule"/>
        /// </summary>
        /// <remarks>Dans une version 2, nous pourrions écrire une énumération
        /// pour limiter le choix des couleurs
        /// </remarks>
        public string Couleur { get; }

        /// <summary>
        /// Propriété permettant d'obtenir la nombr de roue du véhicule
        /// (implémentation de l'interface <see cref="IVehicule"/>
        /// </summary>
        /// <remarks>Cette propriété est mise en abstract pour obliger les sous-classe
        /// de définir la validation du nombre de roues
        /// exemple : Moto --> 2 ou 3
        ///           Voiture --> 4
        ///           Camion --> Tracteur :4
        ///                      Remorque :6 à 8
        /// </remarks>
        public abstract int NbRoues { get; set; }

        /// <summary>
        /// Constructeur du véhicule
        /// (!!! Ne pourra pas être appelé en directe car la classe est abstraite
        ///      MAIS devra être appelé par les sous-classes!!!)
        /// </summary>
        /// <param name="Plaque">La plaque du véhicule</param>
        /// <param name="Marque">La marque du véhicule</param>
        /// <param name="Couleur">La couleur du véhicule</param>
        /// <param name="nbRoues">Le nombre de roues du véhicule</param>
        public Vehicule(string Plaque, string Marque, string Couleur, int nbRoues)
        {
            _plaque = Plaque; //Principe de l'utilisation d'un readonly
            this.Marque = Marque; //Utilisation du pouvoir du constructeur pour init la propriété
            this.Couleur = Couleur;
            this.NbRoues = nbRoues;
        }
        
        
        /// <summary>
        /// Function permettant d'obtenir la liste des actions a effectuer lors
        /// de l'inspection du véhicule.
        /// </summary>
        /// <returns>Un dictionnaire repprenant l'intitulé de l'action et si elle a été effectuée ou pas</returns>
        public virtual Dictionary<EAction, bool> Inspecter()
        {
            Dictionary<EAction, bool> result = new Dictionary<EAction, bool>();
            result.Add(EAction.Liquide_De_Freins, false);
            result.Add(EAction.Pression_Des_Pneus, false);
            result.Add(EAction.Liquide_Lave_Glace, false);
            result.Add(EAction.Remplacer_Pneus, false);
            return result;
        }
    }
}

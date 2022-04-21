using GarageOO.Models.Abstracts;
using GarageOO.Models.Enumerations;
using GarageOO.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageOO.Models.Concretes
{
    /// <summary>
    /// Class représentant une voiture dans notre business
    /// </summary>
    public class Voiture : Vehicule, IVoiture
    {

        /// <summary>
        /// Nombre de portes (Implémentation de <see cref="IVoiture"/>)
        /// </summary>
        public int NbPortes { get; }
        /// <summary>
        /// Capacité du coffre en litre c
        /// </summary>
        public double CapaciteCoffre { get ; set; }
        /// <summary>
        /// Nombre de siège(Implémentation de <see cref="IVoiture"/>)
        /// </summary>
        public int NbSiege { get; }
        /// <summary>
        /// Nombre de roues (Implémentation de <see cref="IVehicule"/>)
        /// </summary>
        private int _nbroues;
        public override int NbRoues
        {
            get { return _nbroues; }
            set
            {
                if (value < 4 || value > 4)
                { throw new WheelsExceptions(); }//Si j'ai moins/ou plus de 4 roues==> je lance l'exception personelle
                else _nbroues = value;
            }
        }
 

        /// <summary>
        /// Constructeur permettant d'intialiser certains champs
        /// faiant appel au constructeur parent pour les propriétés plaque,marque,couleur, nbRoues
        /// <seealso cref="Vehicule"/>
        /// </summary>
        /// <param name="plaque">La plaque en format européen</param>
        /// <param name="marque">La marque de la voiture</param>
        /// <param name="couleur">La couleur de la voiture</param>
        /// <param name="nbRoues">Le nombre de roues</param>
        /// <param name="nbPortes">Le nombre de portes</param>
        /// <param name="NbSiege">Le nombre de siège</param>
        public Voiture(string plaque, string marque, string couleur, int nbRoues, int nbPortes, int NbSiege)
            : base(plaque, marque, couleur, nbRoues)
        {
            this.NbPortes = nbPortes;
            this.NbSiege = NbSiege;
            this.CapaciteCoffre = CapaciteCoffre;//Erreur de débutant où j'affecte la propriété à la propriété car pas de paramètre correspondant
        }

        /// <summary>
        /// Méthode permettant de récupérer les actions d'inspection de la voiture
        /// </summary>
        /// <returns>Un dictionnaire contenant les opération (<see cref="EAction"/>)</returns>
        public override Dictionary<EAction,bool> Inspecter()
        {
            Dictionary<EAction, bool> result = base.Inspecter(); //Récupération du dictionnaire en appelant la méthode parente
            result.Add(EAction.Maj_Gps, false);//Ajout de l'opération supplémentaire
            return result;
        }
    }
}

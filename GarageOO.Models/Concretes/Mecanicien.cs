using GarageOO.Models.Enumerations;
using GarageOO.Models.Interfaces;
using GarageOO.Models.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageOO.Models.Concretes
{
    public delegate bool DelVerifStock(string stock,int nombre);
    public delegate bool DelRetraitPneus(int nombre);    

    /// <summary>
    /// Classe représentant un mécanicien dans notre garage
    /// </summary>
    public class Mecanicien : IMecano
    {
        public event DelVerifStock VerifStock;
        public event DelRetraitPneus RetraitPneus;

        //Propriété permettant de stocker la PK pour le dialogue avec la DB
        public int Id { get; set; }

        /// <summary>
        /// Nom du mécanicien (Implémentation de IMecano)
        /// </summary>
        public string Nom { get; }

        /// <summary>
        /// Nombre de siège désignant l'expertise du mécanicien (Implémentation de IMecano)
        /// </summary>
        public int ExpertisEnNbSiege { get; set; }

        /// <summary>
        /// Tarif barémique du mécanicien déduit de son niveau d'expertise
        /// </summary>
        public double Tarif
        { 
            get {
                return ExpertisEnNbSiege <= 2 ? Bareme.PriMax : Bareme.PriMin;
            } 
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nom">Le nom du mécano</param>
        public Mecanicien(string nom)
        {
            this.Nom = nom;
        }

        /// <summary>
        /// Méthode permettant de savoir si le véhicule peut être pris en charge par le mécanicien
        /// au regard de son expertise
        /// </summary>
        /// <param name="vehicule">Le véhicule qui devra être pris en charge</param>
        /// <returns>True si le mécanicien a l'expertise pour la prise en charge</returns>
        public bool PrendreEnCharge(IVoiture vehicule, out Dictionary<EAction, bool> operations)
        {
            if (vehicule.NbSiege <= ExpertisEnNbSiege)
            {
                operations = vehicule.Inspecter();
                return true;
            }
            else
            {
                operations=null;
                return false;
            }
            //return (vehicule.NbSiege <= ExpertisEnNbSiege);
        }
         
        /// <summary>
        /// Méthode permettant de lancer la réparation du véhicule
        /// </summary>
        /// <param name="vehicule">Le véhicule a réparer</param>
        /// <param name="operations">Les points de contrôle, réparation du véhicule</param>
        /// <returns>True si toutes les réparations ont pu être faites</returns>
        public bool Reparation(IVoiture vehicule,  Dictionary<EAction, bool> operations)
        {
             Random rnd = new Random();
            


            if (operations == null)
            { operations = vehicule.Inspecter(); }
            
            //Mode raccourci
            //operations = operations ?? vehicule.Inspecter();
            //Simuler la réparation
            foreach (KeyValuePair<EAction, bool> item in operations)
            {               
                if(item.Key!= EAction.Remplacer_Pneus)
                { 
                    int val = rnd.Next(0, 98563);
                    operations[item.Key] = val%2==0;
                }
                else

                {
                    //1 vérifier qu'il y a assez de pneus en stock
                    bool IsPossible = VerifStock("Pneus", vehicule.NbRoues);
                    if (IsPossible)
                    {
                        //1.a OK ==> Je valide le changement et retire le nombre de pneus nécessaires
                       
                        //1.a.1 Retirer le nombre de pneus du stock
                        if( RetraitPneus!=null  //Est qu'une classe est abonnée à mon event?
                            && RetraitPneus(vehicule.NbRoues //Ais-je pu retirer le nombre de pneus = nombre de roues?
                            ))
                        {
                             operations[item.Key] = true;
                        }
                        else
                        {
                            operations[item.Key] = false;
                        }
                    }
                    else
                    {
                        //1.b KO ==> Je mets à false l'opération
                        operations[item.Key] = false;
                    }
                }
            }
            return true;
        }
    }
}

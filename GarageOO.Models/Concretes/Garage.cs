using GarageOO.Models.Enumerations;
using GarageOO.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageOO.Models.Concretes
{
    public delegate void DelEmplacement (int numPlace);
    public delegate void DelStock(string Stock, int qte);
    /// <summary>
    /// Classe abstraite permettant de regrouper les caractéristiques
    /// communes des garages
    /// </summary>
    public  class Garage :IGarage
    {
        public event DelEmplacement PlaceTrouvee;//Tableau contenant des fonctions respectant le template déclaré en tant que Delegate
        public event DelStock StockFaible;
        //public string Nom { get; set; } //Auto propriété
        #region Fields (accès interne)
        private string _nom;
            /// <summary>
        /// Les tarifs
        /// </summary>
        /// <remarks>Permet de s'assurer qu'une fois la valeur donnée par 
        /// le constructeur, on ne puisse plus la changer        
        /// </remarks>
            private readonly Dictionary<EAction, double> _tarifs;
            private IVehicule[] _places = new IVehicule[5];
        #endregion
        #region Properties (accès externe)
        /// <summary>
        /// Nom du garage
        /// </summary>
        public string Nom { get { return _nom; } set { _nom = value; } }
        /// <summary>
        /// Tarifs pratiqués par le garage pour les opérations
        /// <see cref="EAction"/>
        /// </summary>
        public Dictionary<EAction, double> Tarifs
            {
                get { return _tarifs; }
            }

        /// <summary>
        /// Les stocks des différents accessoires utiles pour le garage 
        /// tel les pneus
        /// </summary>
        public Dictionary<string, int> Stocks { get; set; } = new Dictionary<string, int>();

       

        /// <summary>
        /// Liste des <see cref="IMecano"/> travaillant dans le garage
        /// </summary>
        public List<IMecano> Mecaniciens { get; set; } = new List<IMecano>();

       
        
        #endregion
        /// <summary>
        /// Constructeur de notre garage permettant de spécifier les tarifs
        /// </summary>
        /// <param name="tarifs">Tarifs pratiqués par le garage</param>
        public Garage(Dictionary<EAction, double> tarifs)
        {
            _tarifs = tarifs;
            Stocks.Add("Pneus", 2);
        }
        /// <summary>
        /// Permet de calculer le prix final ou le devis
        /// </summary>
        /// <param name="travail">Le points contrôlés</param>
        /// <param name="responsable">Le mécano qui a effectué les réparations</param>
        /// <returns>Le prix total TTC</returns>
        public double CalculPrix(Dictionary<EAction,bool> travail, IMecano responsable)
        {
            double TotalHTVA = 0;
            //1- Je dois parcourir chaque opération effectuée et récupérer le tarif associé
            foreach (KeyValuePair < EAction,bool> item in travail)
            {
                if(item.Value) //Est-ce que le travail est fait ?
                {
                    //Récupérer le prix dans la grille tarifaire
                    EAction operation = item.Key; //Freins
                    TotalHTVA += Tarifs[operation]; //Tarifs["Freins"] ==> Valeur du tarif
                }                    
            }
            //2- Multiplier le tarif mecano par le nombre d'opération
            TotalHTVA += (responsable.Tarif * travail.Count());
            //3- Ajouter la tVA (21%)
            double TTC = TotalHTVA * 1.21;
          
            return Math.Round(TTC,2);
        }

        public void StockageVehicule(IVehicule vehicule)
        {
            bool find = false; 
            //Vérifier qu'il y a encore une place dispo
            // si une de dispo--> je récupère le numéro de l'emplacement
            for (int i = 0; i < _places.Length && !find; i++)
            {
                if(_places[i]==null)
                {
                    _places[i] = vehicule;
                    if(PlaceTrouvee!=null) //Est-ce que une autre classe a ajouter une fonction dans le délégué
                    {
                        PlaceTrouvee(i);
                    }
                    find = true;
                }
            }
             
           
        
        }
    
        public void LancerLaJournee()
        {
            IVoiture v = _places[0] as IVoiture;//!!!! A VERIFIER !!!!
            IMecano mecano = Mecaniciens[0];
            if (mecano.PrendreEnCharge(v, out Dictionary<EAction, bool> operations))
            {
                if (mecano.Reparation(v, operations))
                {
                    Console.WriteLine("*****Les opérations effectuées****");

                    //1 Je parcours le dictionnaire pour afficher les opérations effectuées
                    //Console.WriteLine(operations);
                    foreach (KeyValuePair<EAction, bool> item in operations)
                    {
                        if (item.Value) Console.WriteLine($"{item.Key} - V");
                        else Console.WriteLine($"{item.Key} - X");
                    }
                    //OU surcharger la méthode ToString() de notre Dictionary ==> Plus tard dans le cours

                    double prix = this.CalculPrix(operations, mecano);

                    Console.WriteLine($"Vous me devez {prix}€");
                }
                else
                {
                    Console.WriteLine("Impossible de réparer le véhicule Mais nous avons de belles offres sur les voitures de stock");
                }
            }
        }

        public void AjoutPneus(int nb)
        {
            if(Stocks.ContainsKey("Pneus"))
            {
                Stocks["Pneus"] += nb;
            }
            else
            {
                Stocks.Add("Pneus", nb);
            }
        }
        public bool RetraitPneus(int nb)
        {
            if (Stocks.ContainsKey("Pneus"))
            {
                if (nb > Stocks["Pneus"]) return false;
                Stocks["Pneus"] -= nb;
                if (Stocks["Pneus"] <= 8 && Stocks["Pneus"] != 0)
                {
                    if (StockFaible != null) StockFaible("Pneus", Stocks["Pneus"]);
                }
                if (Stocks["Pneus"] == 0)
                {
                    Stocks.Remove("Pneus");
                    //throw new Exception("Plus de pneus");
                    if(StockFaible!=null) StockFaible("Pneus", 0);                    
                }
                
                return true;
            }
            else
            {
                return false;
            }

        }

        public void AddMecaniciens(IMecano mecano)
        {
            //Pour éviter la cast, mettre les events au niveau Interface
            ((Mecanicien)mecano).VerifStock += Garage_VerifStock;
            ((Mecanicien)mecano).RetraitPneus += Garage_RetraitPneus;
            Mecaniciens.Add(mecano);
        }

        private bool Garage_RetraitPneus(int nombre)
        {
            return this.RetraitPneus(nombre);
        }

        private bool Garage_VerifStock(string stock, int nombre)
        {
            if (Stocks[stock] >= nombre)
            {
                return true;
            }
            if (StockFaible != null) StockFaible("Pneus", Stocks["Pneus"]);
            return false;
        }


    }
}

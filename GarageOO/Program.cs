using GarageOO.DAL.Repositories;
using GarageOO.DAL.Repositories.Interface;
using GarageOO.Models;
using GarageOO.Models.Concretes;
using GarageOO.Models.Enumerations;
using GarageOO.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GarageOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Le TechnoGarage");

            /*Création de ma première voiture*/
            Voiture MyFirstCar=null;
            try
            {
                MyFirstCar = new Voiture
                        (
                        plaque: "1-AAA-000",
                        marque: "Lada",
                        couleur: "Mauve",
                        nbRoues: 4,
                        nbPortes: 3,
                        NbSiege: 2);
            }
            catch (WheelsExceptions wex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(wex.Message);
                Console.ResetColor();
                Environment.Exit(-1);
            }
            MyFirstCar.CapaciteCoffre = 152;

            //SauvegarderDans la db
            VoitureRepository repo = new VoitureRepository(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TFGarage;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            if(repo.Add(MyFirstCar))
            {
                Console.WriteLine("Saved in Database");
            }

            //Récupération de la voiture avec l'id 3
            Voiture v = repo.GetOne(3);
            v.CapaciteCoffre = 260;
            repo.Update(v); //Mise à jour dans la DB

            //Récupération de toutes les voitures dans la Db
            List<Voiture> lv = repo.GetAll().ToList();

            //max 5 places de voiture dans mon garage
            // 2 mécaniciens qui peuvent s'occuper des voitures nbsiege > 2
            // 1 mécanicien qui peut s'occuper des voitures ayant nbsiege <=2

            IMecano mecano = new Mecanicien("Roberto Lopez");
            mecano.ExpertisEnNbSiege = 4;

            //Save MEcano dans la DB
            IMecanicienRepository repoMecano = new MecanicienRepository(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TFGarage;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            if(repoMecano.Add(mecano as Mecanicien))
            {
                Console.WriteLine("Ok Roberto est dans la place. Ajout OK");
            }

            Dictionary<EAction, double> MesTarifs = GenerateTarifs();
            Garage Techno = new Garage(MesTarifs);

            //Techno.PlaceTrouvee = lol;
            //Techno.PlaceTrouvee = new DelDeplacement(lol);
            Techno.PlaceTrouvee += lol; //J'informe le garage que lorsque il lancera le délégé Placetrouvé, il faudra 
            Techno.PlaceTrouvee += InfoEmplacement;// exécuter ces fonctions dans ma classe program

            Techno.StockFaible += Techno_StockFaible;

            Techno.StockageVehicule(MyFirstCar);
             
            Techno.AddMecaniciens(mecano);

            //Simuler de stock critique
            //bool RetraitPossible = Techno.RetraitPneus(26);

            ////Simuler une rupture de stock
            //RetraitPossible=  Techno.RetraitPneus(6);



            Techno.LancerLaJournee();
        }

        private static void Techno_StockFaible(string Stock, int qte)
        {
            if(qte==0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            Console.WriteLine($"Le stock {Stock} est faible. Quantité restante : {qte}");
            Console.ResetColor();
        }

        private static Dictionary<EAction, double> GenerateTarifs()
        {
            Dictionary<EAction, double> result = new Dictionary<EAction, double>();
            result.Add(EAction.Pression_Des_Pneus, 54.23);
            result.Add(EAction.Liquide_Lave_Glace, 85);
            result.Add(EAction.Liquide_De_Freins, 25);
            result.Add(EAction.Maj_Gps, 154.28);
            result.Add(EAction.Remplacer_Pneus, 410);
            return result;
        }

        private static void lol (int zorro)
        {
            Console.WriteLine($"Zorro est arrivé en position {zorro}");
        }

        private static void InfoEmplacement(int numPlace)
        {
            Console.WriteLine($"Le véhicule a été placé au n°{numPlace}");
        }
    }
}

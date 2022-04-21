using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FirstAspMvc.Models
{
    public class VoitureViewModel
    {
        /// <summary>
        /// Propriété ajoutée pour permettre le recherche dans la DB
        /// </summary>
        [HiddenInput()]
        public int Id { get; set; }


        
        /// <summary>
        /// Propriété permettant d'atteindre la valeur de la plaque       
        /// </summary>
        [Display(Name ="Plaque Européenne")]
        public string Plaque { get; set; }

        /// <summary>
        /// Propriété permettant d'obtenir la marque du véhicule       
        /// </summary>
        
        [Display(Name ="Marque de la voiture")]
        public string Marque { get; set; }
        /// <summary>
        /// Propriété permettant d'obtenir la couleur du véhicule       
        /// </summary>
        [Required]
        public string Couleur { get; set; }

        /// <summary>
        /// Propriété permettant d'obtenir la nombr de roue du véhicule       
        /// </summary>  
        [Display(Name ="Nombre de roues")]
        public int NbRoues { get; set; }

        /// <summary>
        /// Nombre de portes 
        /// </summary>
        //[Display(Name = "Nombre de portes")] 

        //public int NbPortes { get; set; }
        /// <summary>
        /// Capacité du coffre en litre c
        /// </summary>
        [Display(Name = "Capacité du coffre (Litres)")] 

        public double CapaciteCoffre { get; set; }
        /// <summary>
        /// Nombre de siège
        /// </summary>
        [Display(Name = "Nombre de sièges")] 

        public int NbSiege { get; set; }
    }
}

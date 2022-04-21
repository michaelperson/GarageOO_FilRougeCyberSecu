using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FirstAspMvc.Models.Forms
{
    public class VoitureCreateViewModel
    {
        /// <summary>
        /// Propriété ajoutée pour permettre le recherche dans la DB
        /// </summary>
        [HiddenInput()]
        public int Id { get; set; }        
        
        
        [Required(ErrorMessage ="La plaque est requise")]
        [MaxLength(9)]
        [RegularExpression("[a-z A-Z 1-9]-[a-z A-Z]{3}-[a-z A-Z 1-9]{3}",ErrorMessage ="La plaque doit respecter le format eurpéen")] //A vérifier
        /// <summary>
        /// Propriété permettant d'atteindre la valeur de la plaque       
        /// </summary>
        public string Plaque { get; set; }

        /// <summary>
        /// Propriété permettant d'obtenir la marque du véhicule       
        /// </summary>
        [Required]
        [MaxLength(250)]
        [MinLength(2)]
        public string Marque { get; set; }
        /// <summary>
        /// Propriété permettant d'obtenir la couleur du véhicule       
        /// </summary>
        [Required]        
        public string Couleur { get; set; }

        /// <summary>
        /// Propriété permettant d'obtenir la nombr de roue du véhicule       
        /// </summary>  
        [Required]
        [Range(4,4)]
        public int NbRoues { get; set; }

        /// <summary>
        /// Nombre de portes 
        /// </summary>
        [Required]
        [Range(3, 5)]
        public int NbPortes { get; set; }
        /// <summary>
        /// Capacité du coffre en litre c
        /// </summary>
        [Required] 
        public double CapaciteCoffre { get; set; }
        /// <summary>
        /// Nombre de siège
        /// </summary>
        [Required]
        [Range(2, 8)]
        public int NbSiege { get; set; }
        
    }
}

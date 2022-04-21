using System.Collections.Generic;

namespace FirstAspMvc.Models
{
    /// <summary>
    /// La boite de transport des données vers la vue de notre Home
    /// </summary>
    public class HomeViewModel
    {
        public List<ServicesModel> MesServices { get; set; } 
        public HoraireViewModel Horaire { get; set; }

        public string AboutUs { get; set; } 
    }
}

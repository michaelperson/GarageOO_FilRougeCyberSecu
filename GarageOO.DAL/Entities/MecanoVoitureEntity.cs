using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageOO.DAL.Entities
{
    public class MecanoVoitureEntity
    {
        public int IdMecano { get; set; }
        public int IdVoiture { get; set;}

        //Ajout de deux colonnes supplémentaires
        public DateTime DebutPriseEnCharge { get; set; }
        public DateTime FinPriseEnCharge { get; set; }
    }
}

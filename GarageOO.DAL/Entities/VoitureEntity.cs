using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageOO.DAL.Entities
{
    public class VoitureEntity
    {
        public int Id { get; set; }
        public string Plaque { get; set; }
        public string Marque { get; set; }
        public string Couleur { get; set; }
        public int NbRoues { get; set; }
        public int NbPortes { get; set; }
        public double CapaciteCoffre { get; set; }
        public int NbSiege { get; set; }

        public IEnumerable<MecanicienEntity> Mecaniciens { get; set;}
    }
}

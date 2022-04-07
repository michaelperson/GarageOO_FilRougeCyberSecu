using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageOO.DAL.Entities
{
    public class MecanicienEntity
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Expertise { get; set; }
        public double Tarif { get; set; }

        /// <summary>
        /// Ienumerable pour le côté LazyLoading
        /// Stockage des voitures sur lesquels il travailles
        /// </summary>
        public IEnumerable<VoitureEntity> Voitures { get; set; }

    }
}

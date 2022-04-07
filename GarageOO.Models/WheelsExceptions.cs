using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageOO.Models
{
    public class WheelsExceptions : Exception
    {
        public WheelsExceptions(): base("Le nombre de roue n'est pas valide")
        {

        }
    }
}

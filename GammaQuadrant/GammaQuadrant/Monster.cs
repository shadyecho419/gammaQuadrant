using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M33Universe
{
    class Monster: GalacticBody 
    {
        public bool habitable = false;
        public Queue<Ship> shipsConsumed = new Queue<Ship>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M33Universe
{
   
    class Planet: GalacticBody
    {
        private long surfaceArea = 0;
        public bool colonized { get; set; }
        private long colonisationTime;
        public bool habitable { get; set; }
        private Random random = null;
        public bool homePlanet { get; set; }

        public void setColonisationTime()
        {
            /*
             * calculate and hold colonisation time for the planet
             */
             colonisationTime = (surfaceArea / 2) / (long)0.043;
        }

        public long returnColonisationTime()
        { 
            //return colonisation time
            return colonisationTime;
        }

        public void setSurfaceArea()
        {
            //create a random seed each time surface area is generated to prevent same surface area value
            random = new Random();
            surfaceArea = generateSurfaceArea(0, 100000000);
            random = new Random();
        }

        public long returnSurfaceArea()
        {
            //return surface area when needed
            return surfaceArea;
        }


        private long generateSurfaceArea(long LowerBound, long UpperBound)
        {
            /*
             * random number generator to generate surface area of a planet 
             */
            byte[] buff = new byte[8];
            random.NextBytes(buff);
            long longRand = BitConverter.ToInt64(buff, 0);
            return (Math.Abs(longRand % (UpperBound - LowerBound)) + LowerBound);
        }
    }

   
}

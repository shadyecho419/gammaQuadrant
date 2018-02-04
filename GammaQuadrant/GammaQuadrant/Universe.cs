using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M33Universe
{
    /*
     * implimenting universe as a singleton to ensure there is only one instance of the universe
     * since there are no parelel universes in this situation
     */
    class Universe
    {
        private const long xBound = 999999999;
        private const long yBound = 999999999;
        private const long zBound = 999999999;
        private const int randomLocationCount = 14999;
        private const int totalColonisationTime = 85400;
        private const double colonisationRate = 0.043;
        private const int travelTimeToPlanet = 10;
        private const int travelTimeToMonoster = 20;

        /*
         * Space inside the universe is split into galactic clusters where planets falling
         * withing specific coordinate ranges will be grouped.
         */
        private List<GalacticBody> galacticCluster0 = new List<GalacticBody>();
        private List<GalacticBody> galacticCluster1 = new List<GalacticBody>();
        private List<GalacticBody> galacticCluster2 = new List<GalacticBody>();
        private List<GalacticBody> galacticCluster3 = new List<GalacticBody>();
        private List<GalacticBody> galacticCluster4 = new List<GalacticBody>();
        private List<GalacticBody> galacticCluster5 = new List<GalacticBody>();
        private List<GalacticBody> galacticCluster6 = new List<GalacticBody>();
        private List<GalacticBody> galacticCluster7 = new List<GalacticBody>();
        private List<GalacticBody> galacticCluster8 = new List<GalacticBody>();
        private List<GalacticBody> galacticCluster9 = new List<GalacticBody>();
        private static Universe instance;
        private static Random random = new Random();
        private Universe() { }

        // return or set instance of universe
        public static Universe Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Universe();
                }
                return instance;
            }
        }

        public void addBodyToGalacticCluster(ref GalacticBody body, bool doNotSetCords = false)
        {

            //store galactic bodies in galactic clusters or groupings to make reffering to them easier
            //group done based on distance from origin point of galaxy
            if(doNotSetCords == false)
                body = setCoordinates(ref body);

            if (body.getXCord() > 0 && body.getXCord() < 100000000)
            {
                galacticCluster0.Add(body);
            }
            else if (body.getXCord() > 100000001 && body.getXCord() < 199999999)
            {
                galacticCluster1.Add(body);
            }
            else if (body.getXCord() > 200000000 && body.getXCord() < 299999999)
            {
                galacticCluster2.Add(body);
            }
            else if (body.getXCord() > 300000000 && body.getXCord() < 399999999)
            {
                galacticCluster3.Add(body);
            }
            else if (body.getXCord() > 400000000 && body.getXCord() < 499999999)
            {
                galacticCluster4.Add(body);
            }
            else if (body.getXCord() > 500000000 && body.getXCord() < 599999999)
            {
                galacticCluster5.Add(body);
            }
            else if (body.getXCord() > 600000000 && body.getXCord() < 699999999)
            {
                galacticCluster6.Add(body);
            }
            else if (body.getXCord() > 700000000 && body.getXCord() < 799999999)
            {
                galacticCluster7.Add(body);
            }
            else if (body.getXCord() > 800000000 && body.getXCord() < 899999999)
            {
                galacticCluster8.Add(body);
            }
            else if (body.getXCord() > 900000000 && body.getXCord() < 999999999)
            {
                galacticCluster9.Add(body);
            }
        }

        public long xBroundProperty
        {
            get { return xBound; }
        }

        public long yBroundProperty
        {
            get { return yBound; }
        }

        public long zBroundProperty
        {
            get { return zBound; }
        }

        public int returnPlanetCount()
        {
            return randomLocationCount;
        }

        private GalacticBody setCoordinates(ref GalacticBody body)
        {
            //remember to build in prevention of repeating coordinates here
            long newXCord = generateCords(0, xBroundProperty);
            long newYCord = generateCords(0, yBroundProperty);
            long newZCord = generateCords(0, zBroundProperty);
            bool check = true;

            while (check == true)
            {
                if (checkForUniqueCoordinates(newXCord, newYCord, newZCord) == true)
                {
                    newXCord = generateCords(0, xBroundProperty);
                    newYCord = generateCords(0, yBroundProperty);
                    newZCord = generateCords(0, zBroundProperty);
                }
                else
                {   
                    check = false;
                }
            }

            body.splitNumber(newXCord);
            body.setXCord(newXCord);
            body.setYCord(newYCord);
            body.setZCord(newZCord);
            return body;
        }

        private long generateCords(long LowerBound, long UpperBound)
        {
            /*
             * random number generator to coordinantes for planet
             */
            byte[] buff = new byte[8];
            random.NextBytes(buff);
            long longRand = BitConverter.ToInt64(buff, 0);
            return (Math.Abs(longRand % (UpperBound - LowerBound)) + LowerBound);
        }


       /*
        * check all galactic clusters to make sure we are not using exisitng already used
        * to place a new galactic body
        */
        private bool checkForUniqueCoordinates(long cordX, long cordY, long cordZ)
        {
            foreach (var val in galacticCluster0)
            {
                if (cordX == val.getXCord() && cordY == val.getYCord() && val.getZCord() == cordZ)
                    return true;
                else
                    return false;
            }

            foreach (var val in galacticCluster1)
            {
                if (cordX == val.getXCord() && cordY == val.getYCord() && val.getZCord() == cordZ)
                    return true;
                else
                    return false;
            }

            foreach (var val in galacticCluster2)
            {
                if (cordX == val.getXCord() && cordY == val.getYCord() && val.getZCord() == cordZ)
                    return true;
                else
                    return false;
            }

            foreach (var val in galacticCluster3)
            {
                if (cordX == val.getXCord() && cordY == val.getYCord() && val.getZCord() == cordZ)
                    return true;
                else
                    return false;
            }

            foreach (var val in galacticCluster4)
            {
                if (cordX == val.getXCord() && cordY == val.getYCord() && val.getZCord() == cordZ)
                    return true;
                else
                    return false;
            }

            foreach (var val in galacticCluster5)
            {
                if (cordX == val.getXCord() && cordY == val.getYCord() && val.getZCord() == cordZ)
                    return true;
                else
                    return false;
            }

            foreach (var val in galacticCluster6)
            {
                if (cordX == val.getXCord() && cordY == val.getYCord() && val.getZCord() == cordZ)
                    return true;
                else
                    return false;
            }

            foreach (var val in galacticCluster7)
            {
                if (cordX == val.getXCord() && cordY == val.getYCord() && val.getZCord() == cordZ)
                    return true;
                else
                    return false;
            }

            foreach (var val in galacticCluster8)
            {
                if (cordX == val.getXCord() && cordY == val.getYCord() && val.getZCord() == cordZ)
                    return true;
                else
                    return false;
            }

            foreach (var val in galacticCluster9)
            {
                if (cordX == val.getXCord() && cordY == val.getYCord() && val.getZCord() == cordZ)
                    return true;
                else
                    return false;
            }

            return false;
        }
    }
}

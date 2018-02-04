using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M33Universe
{
    class Program
    {
        static void Main(string[] args)
        {
            //create instace of the universe firstly
            Universe m33 = Universe.Instance;

            //generate home planet
            Planet homePlanet = new Planet();
            homePlanet.colonized = true;
            homePlanet.homePlanet = true;
            homePlanet.habitable = true;
            homePlanet.setSurfaceArea();
            homePlanet.setXCord(123123991);
            homePlanet.setYCord(98098111);
            homePlanet.setZCord(456456999);

            GalacticBody homePlanetBody = (GalacticBody)homePlanet;
            m33.addBodyToGalacticCluster(ref homePlanetBody, true);
            homePlanetBody = null;
            homePlanet = null;

            //create galactic object
            Random rand = new Random();
            for (int i=0; i< m33.returnPlanetCount(); i++)
            {        
                if (rand.Next(0, 2) == 0)
                {
                    //create planet
                    Planet planet = new Planet();
                    planet.colonized = false;
                    planet.habitable = true;
                    planet.homePlanet = false;

                    planet.setSurfaceArea();
                    GalacticBody body = (GalacticBody)planet;
                    m33.addBodyToGalacticCluster(ref body);
                    planet = null;
                    body = null;
                }
                else
                {
                    //create monster
                    Monster monster = new Monster();
                    GalacticBody body = (GalacticBody)monster;
                    m33.addBodyToGalacticCluster(ref body);
                    monster = null;
                    body = null;
                }
            }      
        }
    }
}

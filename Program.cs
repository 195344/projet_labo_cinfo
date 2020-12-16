using System;
using Simulation;
using Prod;
using Cons;
using WireNode;
using System.Collections.Generic;

namespace projet_labo_cinfo
{
    class Program
    {
        static void Main(string[] args)
        {   
            MarketSimulation france = new MarketSimulation();
            WeatherSimulation belgique = new WeatherSimulation(0,0);
            //NuclearPlant myprod = new NuclearPlant(1000,0,france);
            SolarPlant myprod = new SolarPlant(0,1,belgique);
            //GasPlant myprod = new GasPlant(3,2,1);
            Console.WriteLine(myprod.getProduction());
            Console.WriteLine(myprod.getCost());
            Console.WriteLine(myprod.getEmission());




            //add a producer ;
            GasPlant gasProd1 = new GasPlant(3,2, france );
            //Try to built a network
            // first of all the node 
            DistribNode distrib1 = new DistribNode();  
            DistribNode distrib2 = new DistribNode();
            DistribNode distrib3 = new DistribNode();

            ConcentNode concentrator1= new ConcentNode();

            
            // Next the wire and add it to a node 
            Wire myprodWire = new Wire(myprod, distrib1,12);  
            //distrib1.SetPowerSupply(myprodWire);
            Wire gasWire= new Wire(gasProd1,distrib2,20);
            //distrib2.SetPowerSupply(gasWire);

            Wire wire1Concen1 = new Wire(concentrator1,distrib2,8 ); 
            Wire wire2Concen1 = new Wire(concentrator1,distrib1,8 ); 

            Wire wireNodeNode1 =new Wire(distrib2, distrib3,20);


            //after
            City paris= new City(12,"Longitude=1,Latitude=1","Paris");
            Wire parisWire = new Wire(paris,distrib3,10);


            Company ferrero = new Company(12,"Longitude = 12, latitude =8", "ferrero");
            Wire ferreroWire = new Wire(ferrero, distrib3,12);


            Dissipaters dis1 = new Dissipaters (14,"Longitude = 12, latitude =19");
            Wire disipWire = new Wire(dis1, distrib1,4);

            // now we connect all the wire to the nodes 
            distrib1.SetPowerSupply(myprodWire);
            Console.WriteLine("le sourant est de "+distrib1.GetActivCurrent());
            distrib1.AddConnection(wire1Concen1);
            distrib1.AddConnection(disipWire);
            double []  distributionProportions={0.7,0.3};
            
            distrib1.SetEnergyDistrib(distributionProportions);
            
            // juste pour controler si j'ai pas de problèmes
            List<Wire> wireliste = new List<Wire>();
            wireliste=distrib1.GetConnetions();
            Console.WriteLine("nombre de fils : " + wireliste.Count);
            Console.WriteLine("le courant est de "+wireliste[1].GetCost() ) ;
            foreach (Wire fils in wireliste)
            {
                Console.WriteLine("le fils est : "+ fils.GetMaxCurrent()+"Activ current = "+fils.GetActivCurrent());
            }
            // fin
            Console.WriteLine("production gas line " +gasWire.GetActivCurrent());

            distrib2.SetPowerSupply(gasWire);
            distrib2.AddConnection(wire2Concen1);
            double []  distributionProportions2={1};
            Console.WriteLine("essais"+distrib2.GetActivCurrent());
            distrib2.SetEnergyDistrib(distributionProportions2);
            Console.WriteLine("essais2 "+wire2Concen1.GetActivCurrent());
            // fonctionne jusque ici !


            concentrator1.SetConcentreWire(wireNodeNode1);
            concentrator1.AddConnection(wire1Concen1);
            concentrator1.AddConnection(wire2Concen1);
            
        
            distrib3.SetPowerSupply(wireNodeNode1);
            distrib3.AddConnection(ferreroWire);
            distrib3.AddConnection(parisWire);


            //
            paris.SetQuantityEnergie(2);

            Console.WriteLine("enregie dans le fils node node : "+wireNodeNode1.GetActivCurrent());
            Console.WriteLine("le prix/kwh sur le neud distrib3 est : "+distrib3.GetCost());
            Console.WriteLine("Le prix pour la ville de paris est : "+ paris.GetCost(parisWire));

            


            
        }
    }
}

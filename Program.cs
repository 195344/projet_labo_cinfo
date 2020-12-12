using System;
using Simulation;
using Prod;
using Cons;

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

            City paris= new City(12,"11eme arondissement","Paris");
            Dissipateur dis1 = new Dissipateur (14,"Paris");
            Console.WriteLine(paris.QuantityEnergie);
            paris.QuantityEnergie=9;
            Console.WriteLine(paris.QuantityEnergie);


            
        }
    }
}

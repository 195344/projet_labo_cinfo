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
            Console.WriteLine(france.UraniumPrice());
            //NuclearPlant myprod = new NuclearPlant(3,2);
            GasPlant myprod = new GasPlant(3,2,1);
            Console.WriteLine(myprod.Production);
            Console.WriteLine(myprod.Cost);
            Console.WriteLine(myprod.Emission);

            City paris= new City(12,"11eme arondissement","Paris");
            Dissipateur dis1 = new Dissipateur (14,"Paris");
            Console.WriteLine(paris.QuantityEnergie);
            paris.QuantityEnergie=9;
            Console.WriteLine(paris.QuantityEnergie);


            
        }
    }
}

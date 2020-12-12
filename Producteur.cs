using Simulation;
namespace Prod
{
    // public class Producer
    // {
    //     private double production;
    //     private double cost;
    //     private double emission;

    //     public Producer(double production, double cost, double emission)
    //     {
    //         this.production=production;
    //         this.cost=cost;
    //         this.emission=emission;
    //     }

    //     public double Production
    //     {
    //         get { return production; }
    //         set { production = value; }
    //     }

    //     public double Cost
    //     {
    //         get { return cost; }
    //     }

    //     public double Emission
    //     {
    //         get { return emission; }
    //     }
    // }
    interface Producer
    {
        public double getProduction();
        public double getCost();
        public double getEmission();
    }

    public class GasPlant : Producer
    {
        private double emission;
        private double production;
        private MarketSimulation marketsimulation;
        public GasPlant(double production, double emission, MarketSimulation marketsimulation)
        {
            this.production=production;
            this.emission=emission;
            this.marketsimulation=marketsimulation;
        }

        public double getProduction()
        {
            return production;
        }

        public void setProduction(double value)
        {
            production=value;
        }
        
        public double getCost()
        {
            //add code to compute prduction cost
            return marketsimulation.GasPrice()/1000;
        }
        
        public double getEmission()
        {
            return emission;
        }

    }

    public class NuclearPlant : Producer
    {
        private double production;
        private double emission;
        private double production_real;
        private MarketSimulation marketsimulation;
        public NuclearPlant(double production, double emission, MarketSimulation marketsimulation)
        {
            this.production=production;
            this.production_real=production;
            this.emission=emission;
            this.marketsimulation=marketsimulation;
        }

        public double getProduction()
        {
            return production_real;
        }

        public void SwitchOff()
        {
            production_real=0;
        }

        public void SwitchOn()
        {
            production_real=production;
        }
        
        public double getCost()
        {
            //add code to compute prduction cost
            return marketsimulation.UraniumPrice()/1000;
        }
        
        public double getEmission()
        {
            return emission;
        }
    }

    public class WindPlant : Producer
    {
        private double emission;
        private double cost;
        private WeatherSimulation weathersimulation;
        public WindPlant(double emission, double cost, WeatherSimulation weathersimulation)
        {
            this.emission=emission;
            this.cost=cost;
            this.weathersimulation=weathersimulation;
        }

        public double getProduction()
        {
            //add code to compute production
            return weathersimulation.Wind()*10;
        }
        
        public double getCost()
        {
            return cost;
        }
        
        public double getEmission()
        {
            return emission;
        }

    }

    public class SolarPlant : Producer
    {
        private double emission;
        private double cost;
        private WeatherSimulation weathersimulation;
        public SolarPlant(double emission, double cost, WeatherSimulation weathersimulation)
        {
            this.emission=emission;
            this.cost=cost;
            this.weathersimulation=weathersimulation;
        }

        public double getProduction()
        {
            //add code to compute production
            return weathersimulation.Sunshine()*10;
        }
        
        public double getCost()
        {
            return cost;
        }
        
        public double getEmission()
        {
            return emission;
        }

    }

    public class BuyElectricity : Producer
    {
        private double production;
        private double emission;
        private MarketSimulation marketsimulation;
        public BuyElectricity(double production, double emission, MarketSimulation marketsimulation)
        {
            this.production=production;
            this.emission=emission;
            this.marketsimulation=marketsimulation;
        }

        public double getProduction()
        {
            //add code to compute production
            return production;
        }

        public void setProduction(double value)
        {
            production=value;
        }
        
        public double getCost()
        {
            return marketsimulation.ElectricityBuyPrice();
        }
        
        public double getEmission()
        {
            return emission;
        }

    }
}
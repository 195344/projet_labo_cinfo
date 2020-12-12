namespace Prod
{
    public class Producer
    {
        private double production;
        private double cost;

        public Producer(double production, double cost)
        {
            this.production=production;
            this.cost=cost;
        }

        public double Production
        {
            get { return production; }
            set { production = value; }
        }

        public double Cost
        {
            get { return cost; }
        }
    }

    public class GasPlant : Producer
    {
        private double emission;

        public GasPlant(double production, double cost, double emission) : base(production, cost)
        {
            this.emission = emission;
        }

        public double Emission
        {
            get { return emission; }
        }
    }

    public class NuclearPlant : Producer
    {
        private double emission ;

        public NuclearPlant(double production, double cost) : base(production, cost)
        {
            this.emission = 0;
        }

        public double Emission
        {
            get { return emission; }
        }
    }
}
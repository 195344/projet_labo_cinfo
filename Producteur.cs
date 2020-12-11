namespace Prod
{
    interface Producteur{
        
        double Production { get; }
        double Cout { get; }
        double Emission { get; }
    }

    public class Centrale_Gaz : Producteur{
        private double production;
        private double cout;
        private double emission;

        public Centrale_Gaz(double production, double cout, double emission){
            this.production = production;
            this.cout = cout;
            this.emission = emission;
        }

        public double Production{
            get {return production;}
            set {production = value;}
        } 

        public double Cout{
            get {return cout;}
        } 

        public double Emission{
            get {return emission;}
        }
    }

    public class Centrale_Nucleaire : Producteur{
        private double production;
        private double cout;
        private double emission = 0;

        public Centrale_Nucleaire(double production, double cout){
            this.production = production;
            this.cout = cout;
        }

        public double Production{
            get {return production;}
            set {production = value;}
        } 

        public double Cout{
            get {return cout;}
        } 

        public double Emission{
            get {return emission;}
        }
    }
}
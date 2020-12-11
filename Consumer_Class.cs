namespace Cons
{


    public class Consumer
    {



        private int quantityEnergie;


        private string localization;


        public Consumer(int quantityEnergie, string localization)
        {
            this.quantityEnergie=quantityEnergie;
            this.localization=localization;


        }

        public int QuantityEnergie
        {
            get { return quantityEnergie; }
            set { quantityEnergie = value; }
        }



    }

    public class City : Consumer
    {
        private string nameCity;
        public City(int quantityEnergie, string localization, string nameCity) : base(quantityEnergie, localization)
        {
            this.nameCity = nameCity;
        }


    }

    public class Entreprise : Consumer
    {

        private string nameCompany;

        public Entreprise(int quantityEnergie, string localization, string nameCompany) : base(quantityEnergie, localization)
        {
            this.nameCompany = nameCompany;

        }


    }

    public class Dissipateur : Consumer
    {

        public Dissipateur(int quantityEnergie, string localization) : base(quantityEnergie, localization)
        {

        }


    }

}

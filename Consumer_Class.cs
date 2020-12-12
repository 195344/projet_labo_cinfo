using WireNode;
namespace Cons
{


    public abstract class Consumer
    {



        private int quantityEnergie;


        private string localization;

        public Consumer (int quantityEnergie, string localization)
        {
            this.quantityEnergie=quantityEnergie;
            this.localization=localization;


        }

        public int GetQuantityEnergie ()
        { 
            return quantityEnergie; 
        }

        public void SetQuantityEnergie (int quantityEnergie)
        {
            this.quantityEnergie = quantityEnergie; 
        }
        

        public double GetCost( Wire connectedWire )
        {
            return quantityEnergie*connectedWire.GetCost();
            // Nous devons trouver une solution pour le prix.... 
            //qu'il puisse varier en fonction de la producion globale ou alors en proportion de chaque source d'energie reçu 
            // si nous faison selon la deuxième méthode je suggere que nous attribuions a chaque noeud une proportion de l'energie recu en 
            //fonction de la production 

            // Bon finalement je l'ai fait nous en discuterons
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

    public class Company : Consumer
    {

        private string nameCompany;

        public Company(int quantityEnergie, string localization, string nameCompany) : base(quantityEnergie, localization)
        {
            this.nameCompany = nameCompany;

        }


    }

    public class Dissipaters : Consumer
    {

        public Dissipaters(int quantityEnergie, string localization) : base(quantityEnergie, localization)
        {

        }


    }

}

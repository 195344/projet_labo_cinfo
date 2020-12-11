namespace Consumer

    //interface 

public abstract class Consumer	
{
	


        private int _quantityEnergie;
        
        private string typeCons;
        private string localization;


        public Consumer(int _quantityEnergie, string localization)
        {
            this.typeCons = typeCons;
            this.connexion = connexion;
        }

        public int QuantityEnergie
        {
            get { return _quantityEnergie; }
            set { _quantityEnergie = value; }
        }



}

public class City : Consumer
{

    private string nameCity;
     

    public Ville (:,string nameCity)
    {
        this.nameCity = nameCity; 

    }


}




public class Entreprise : Consumer
{

    private string nameCompany;

    public Entreprise(:, string nameCompany)
    {
        this.nameCompany = nameCompany;

    }


}

public class Dissipateur : Consumer
{


    public Dissipateur()
    {
        
    }


}


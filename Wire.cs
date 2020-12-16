
using Prod;
using Cons;
using System.Collections.Generic;
using System;


namespace WireNode{

    

    public abstract class Node
    {
        protected List < Wire > connetions; 
        protected double costByEnegieQtt;
       

        public abstract void AddConnection(Wire wire);
        

        public List<Wire> GetConnetions ()
        {
            return connetions;
        }
        public abstract double GetCost() ;    


    }
    public class DistribNode: Node
    {

        public DistribNode()
        {
            connetions = new List<Wire>();           

        }
        public void SetPowerSupply(Wire powerSupply)
        {
            connetions.Insert(0,powerSupply);
            costByEnegieQtt=powerSupply.GetCost();

        }
        public override void AddConnection (Wire wire)
        {
            connetions.Add(wire);
        }
        
        public override double GetCost()
        {
            return costByEnegieQtt;
        }
        // here we set the current distribution in each branch of the distribution node wire
        public void SetEnergyDistrib( double[] distribProportions )
        { 
            //Console.WriteLine("test de connexion capacity "+connetions.Count);
            //Console.WriteLine("Energie d'arrivé "+connetions[0].GetActivCurrent());

            for(int i=1; i<connetions.Count;i++)
            {                
                connetions[i].SetActivCurrent(distribProportions[i-1]*connetions[0].GetActivCurrent());
                
            }
            
        }

        public double GetActivCurrent(){
            return connetions[0].GetActivCurrent();
        }


    }
    public class ConcentNode :Node
    {
        private double energyRecived;
        public ConcentNode( )
        {
            connetions = new List<Wire>();

        }

        public void SetConcentreWire(Wire concentredWire)
        {
            connetions.Insert (0,concentredWire);
        }

        public override double GetCost() // we try to divide each cost by quantityEnergie recive to obtain a average  an cost
        {
            foreach( Wire aWire in connetions)
            {
                costByEnegieQtt=aWire.GetCost()/aWire.GetActivCurrent();
            }
            return costByEnegieQtt;
        }
        public override void AddConnection(Wire wire)
        {
            connetions.Add(wire);
            energyRecived += wire.GetActivCurrent();
            connetions[0].SetActivCurrent(energyRecived);
        }


        // a suprimer 
        public void actualiseCurrent()
        {
            // Summ of all energy in each wire
            for(int i=1;i<=connetions.Count;i++ )
            {
                energyRecived += connetions[i].GetActivCurrent();
            }
            connetions[0].SetActivCurrent(energyRecived);
        }
 
        
    }




    public class Wire
    {

        private double maxCurrent;
        private double activCurrent;
        private double cost ;

        
        private object a;
        private object b;


        public Wire ( Producer a,Consumer b,double maxCurrent)
        {
            this.a = a;
            this.b = b;
            this.maxCurrent = maxCurrent;
            this.activCurrent=a.getProduction();
            cost=a.getCost();

        }
        public Wire(Consumer a , Producer b,double maxCurrent)
        {
            this.a = a;
            this.b = b;
            this.maxCurrent = maxCurrent;
            this.activCurrent=b.getProduction();
            
            cost=b.getCost();

        }
        public Wire(Node a , Consumer b,double maxCurrent)
        {
            this.a = a;
            this.b = b;
            this.maxCurrent = maxCurrent;
            
            this.cost=a.GetCost();

        }
        public Wire( Consumer a, Node b ,double maxCurrent)
        {
            this.a = a;
            this.b = b;
            this.maxCurrent = maxCurrent;
            this.cost=b.GetCost();

        }
        public Wire( Node a, Node b ,double maxCurrent )
        {
            this.a = a;
            this.b = b;
            this.maxCurrent = maxCurrent;
            if (a is DistribNode)
            {
                this.cost=a.GetCost();
            }
            else
            {
                this.cost=b.GetCost();

            }

        }
       public Wire(Producer a, DistribNode b,double maxCurrent)
       {
           this.a = a;
           this.b = b;
           this.maxCurrent = maxCurrent;
           this.activCurrent=a.getProduction();
           cost=a.getCost();

       }
       public Wire(DistribNode a,Producer b ,double maxCurrent)
       {
           this.a=a;
           this.b=b;
           this.maxCurrent = maxCurrent;
           cost=b.getCost();
           this.activCurrent=b.getProduction();
       }



       public double GetActivCurrent()
       {
           return activCurrent ;
       }
       public void SetActivCurrent(double activCurrent)
       {
            this.activCurrent=activCurrent;
       }
       public double GetMaxCurrent()
       {
           return maxCurrent;
       }

        public object GetConnetionA()
        {
            return a;

        }
        public object GetConnetionB()
        {
            return b; 

        }

        public double GetCost()
        {
            return cost;
        }

    }
}
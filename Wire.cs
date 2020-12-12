
using Prod;
using Cons;
using System.Collections.Generic;


namespace WireNode{

    

    public abstract class Node
    {
        protected List < Wire > connetions; 
        protected double costByEnegieQtt;

        public void AddConnection(Wire wire)
        {
            connetions.Add(wire);
        }

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
        
        public override double GetCost()
        {
            return costByEnegieQtt;
        }

    }
    public class ConcentNode :Node
    {
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

        
        
    }




    public class Wire
    {

        private int maxCurrent;
        private int activCurrent;
        private double cost ;
        
        private object a;
        private object b;


        public Wire ( Producer a,Consumer b,int maxCurrent)
        {
            this.a = a;
            this.b = b;
            this.maxCurrent = maxCurrent;
            cost=a.getCost();

        }
        public Wire(Consumer a , Producer b,int maxCurrent)
        {
            this.a = a;
            this.b = b;
            this.maxCurrent = maxCurrent;
            cost=b.getCost();

        }
        public Wire(Node a , Consumer b,int maxCurrent)
        {
            this.a = a;
            this.b = b;
            this.maxCurrent = maxCurrent;
            this.cost=a.GetCost();

        }
        public Wire( Consumer a, Node b ,int maxCurrent)
        {
            this.a = a;
            this.b = b;
            this.maxCurrent = maxCurrent;
            this.cost=b.GetCost();

        }
        public Wire( Node a, Node b ,int maxCurrent )
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
       public Wire(Producer a, DistribNode b,int maxCurrent)
       {
           this.a = a;
           this.b = b;
           this.maxCurrent = maxCurrent;
           cost=a.getCost();

       }
       public Wire(DistribNode a,Producer b ,int maxCurrent)
       {
           this.a=a;
           this.b=b;
           this.maxCurrent = maxCurrent;
           cost=b.getCost();
       }



       public int GetActivCurrent()
       {
           return activCurrent ;
       }

       public void SetActivCurrent(int activCurrent)
       {
            this.activCurrent=activCurrent;
       }

       public int GetMaxCurrent()
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
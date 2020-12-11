using System;
using Prod;

namespace projet_labo_cinfo
{
    class Program
    {
        static void Main(string[] args)
        {   
            Producteur myprod = new Centrale_Nucleaire(1,1);
            Console.WriteLine(myprod.Production);
            Console.WriteLine(myprod.Emission);
        }
    }
}

using System;
using Prod;

namespace Projet
{
    class Program
    {
        static void Main(string[] args)
        {
            Producteur myprod = new Centrale_Gaz(1,1,1);
            Console.WriteLine(myprod.Production);
            Console.WriteLine(myprod.Production);
        }
    }
}

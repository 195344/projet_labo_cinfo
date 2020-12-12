
using Prod;
using Cons;
using nod;
namespace W{

    public class Wire{

        private int limitedCurrent;
        private int activCurrent;

        public Wire(Centrale_Nucleaire a , Consumer b){
          

        }
        public Wire(Consumer a , Centrale_Nucleaire b){

        }
        public Wire(Node a , Consumer b){

        }
        public Wire( Consumer b, Node a ){
          

        }
        public Wire( Node b, Node a ){

        }

       public Wire(Centrale_Nucleaire a, DistribNode b){

       }
       public Wire(DistribNode b,Centrale_Nucleaire a ){

       }


    }
}
using MulticastDelegates.Service;

namespace MulticastDelegates
{
    delegate void BinaryNumbericOperation(double n1, double n2);
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();

            // Multicast Delegates guardam referência para mais de um método;
            // Pode-se usar o operador +=
            // A chamada Invoke (ou sintaxe reduzida) executa todos os métodos
            // na ordem em que foram adicionados
            // Seu uso faz sentido para métodos void
            double a = 10;
            double b = 15;
            BinaryNumbericOperation op = CalculationService.ShowSum;
            op += CalculationService.ShowMax;

            op(a, b);
        }


    }
}

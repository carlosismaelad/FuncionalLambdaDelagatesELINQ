using DelegatesIntroducao.Services;

namespace DelegatesIntroducao
{
    delegate double BinaryNumericOperation(double n1, double n2);
    delegate double NumericOperationSquare(double n1);
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();

            double a = 10;
            double b = 12;

            //usando o delgate
            BinaryNumericOperation sm = CalculationService.Sum;

            // Sintaxe diferente - mais verbosa
            BinaryNumericOperation mx = new BinaryNumericOperation(CalculationService.Sum);

            // Precisamos criar um delegate diferente para Square porque
            // declaramos que nosso delegate BinaryNumericOperation
            // recebe DOIS valores double. A Assinuatura de BinaryNumericOperation 
            // não casa com o Square.
            NumericOperationSquare sqrt = CalculationService.Square;

            double resultSum = sm(a, b);
            double resultMax = mx(a, b);
            double resultSqrt = sqrt(a);

            Console.WriteLine(resultSum);
            Console.WriteLine(resultMax);
            Console.WriteLine(resultSqrt);

        }
    }
}
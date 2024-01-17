namespace ProgFuncionalELambda
{
    class Program
    {
        public static int globalValue = 3;
        public static void Main(string[] args)
        {
            Console.Clear();

            // EXPRESSIVIDADE

            // Programação imperativa
            List<int> list = new List<int>();
            int sum = 0;
            foreach (int x in list)
            {
                sum += x;
            }

            // Funcional
            int soma = list.Aggregate(0, (x, y) => x + y);


            // SOBRE TRANSPARÊNCIA REFERENCIAL
            // Sem transparência referencial porque
            // depende de elementos de "fora".
            // Na prpgramação funcional transparência referencial
            // é um aspecto mais forte.
            int[] vect = new int[] { 3, 4, 5 };
            ChangeOddValues(vect);
            Console.WriteLine(string.Join(" ", vect));

            // OUTRAS CARACTERÍSTICAS DE PROG FUNCIONAL:
            // 1 -Funções são elementos de primeira ordem: podem ser passadas
            // como parâmetro de outras funções;
            // 2 - Usamos mais inferência de tipos;
            // 3 - Execução tardia (lazy), comum em prog funcional.
        }

        public static void ChangeOddValues(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    numbers[i] += globalValue;
                }
            }
        }
    }
}

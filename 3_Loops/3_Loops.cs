namespace _3_Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fib1 = 0, fib2 = 1, tmp;
            Console.WriteLine("Fibonaccy:");
            for (int i = 0; i < 10; i++) {
                Console.WriteLine(fib2);
                tmp = fib2;
                fib2 = fib1 + fib2;
                fib1 = tmp;
            }
            Console.WriteLine("Even numbers:");
            for (int i = 2; i <= 20; i+=2) {
                Console.WriteLine(i);
            }
            Console.WriteLine("Multiplication table:");
            for (int i = 1; i <= 5; i++) {
                for (int j = 1; j <= 5; j++) {
                    Console.WriteLine( "{0} * {1} = {2}", i, j, i*j);
                }
            }
            string res;
            string password = "qwerty";
            do
            {
                Console.WriteLine("Input password:");
                res = Console.ReadLine();
                if (res == password)
                {
                    Console.WriteLine("Correct password");
                }
                else
                {
                    Console.WriteLine("Wrong password");
                }

            } while (res != password);

        }
    }
}

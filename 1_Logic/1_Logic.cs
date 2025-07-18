using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Input first number: ");
        if (!Int32.TryParse(Console.ReadLine(), out int a))
        {
            Console.WriteLine("Not a Number!");
            return;
        }

        Console.Write("Input second number: ");
        if (!Int32.TryParse(Console.ReadLine(), out int b))
        {
            Console.WriteLine("Not a Number!");
            return;
        }
        Console.Write("Input operator (+, -, *, /, &, |, ^): ");
        string s = Console.ReadLine();
        if (s.Length == 0 || s.Length > 1)
        {
            Console.WriteLine("Wrong sign");
            return;
        }

        switch (s[0])
        {
            case '+':
                Console.WriteLine("Result of {0} + {1} = {2} (0b{3}, 0x{4})", a, b, a + b, Convert.ToString(a + b, 2), Convert.ToString(a + b, 16));
                break;
            case '-':
                Console.WriteLine("Result of {0} - {1} = {2} (0b{3}, 0x{4})", a, b, a - b, Convert.ToString(a - b, 2), Convert.ToString(a - b, 16));
                break;
            case '*':
                Console.WriteLine("Result of {0} * {1} = {2} (0b{3}, 0x{4})", a, b, a * b, Convert.ToString(a * b, 2), Convert.ToString(a * b, 16));
                break;
            case '/':
                Console.WriteLine("Result of {0} / {1} = {2} (0b{3}, 0x{4})", a, b, a / b, Convert.ToString(a / b, 2), Convert.ToString(a / b, 16));
                break;
            case '&':
                Console.WriteLine("Result of {0} & {1} = {2} (0b{3}, 0x{4})", a, b, a & b, Convert.ToString(a & b, 2), Convert.ToString(a & b, 16));
                break;
            case '|':
                Console.WriteLine("Result of {0} | {1} = {2} (0b{3}, 0x{4})", a, b, a | b, Convert.ToString(a | b, 2), Convert.ToString(a | b, 16));
                break;
            case '^':
                Console.WriteLine("Result of {0} ^ {1} = {2} (0b{3}, 0x{4})", a, b, a ^ b, Convert.ToString(a ^ b, 2), Convert.ToString(a ^ b, 16));
                break;
            default:
                Console.WriteLine("Wrong sign");
                break;
        }
    }
}


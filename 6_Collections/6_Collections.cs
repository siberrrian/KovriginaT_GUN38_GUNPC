using System.Collections.Generic;
using System.Threading.Tasks;

namespace _6_Collections
{
    internal class Program
    {
        private class Task1List
        {
            private List<string> _listOfStrings = new List<string>();

            public void TaskLoop()
            {
                string inputString = "";
                _listOfStrings.Add("First string");
                _listOfStrings.Add("Second string");

                Console.WriteLine("Enter string ('-exit' for exit):");
                inputString = Console.ReadLine().Trim();

                while (!inputString.Equals("-exit"))
                {
                    _listOfStrings.Add(inputString);
                    Console.WriteLine("Enter string ('-exit' for exit):");
                    inputString = Console.ReadLine().Trim();
                }

                Console.WriteLine("The list contains strings");
                for (int i = 0; i < _listOfStrings.Count; i++)
                {
                    Console.WriteLine(_listOfStrings[i]);
                }

                Console.WriteLine("Enter a string to insert into the middle of the list:");
                inputString = Console.ReadLine();

                _listOfStrings.Insert(_listOfStrings.Count / 2, inputString);
                Console.WriteLine("The list contains strings");
                for (int i = 0; i < _listOfStrings.Count; i++)
                {
                    Console.WriteLine(_listOfStrings[i]);
                }

            }
        }

        private class Task2Dict
        {
            private Dictionary<string, int> dict = new Dictionary<string, int>();
            public void TaskLoop()
            {
                Console.WriteLine("Enter the student's name ('-exit' for exit):");
                string inputName = Console.ReadLine().Trim();
                while (!inputName.Equals("-exit"))
                {
                    Console.WriteLine("Enter student grade from 2 to 5:");
                    int inputGrade;
                    while (!int.TryParse(Console.ReadLine(), out inputGrade) || (inputGrade < 2 || inputGrade > 5))
                    {
                        Console.WriteLine("Enter student grade from 2 to 5:");
                    }
                    dict.Add(inputName, inputGrade);

                    Console.WriteLine("Enter the name of the student whose grade you want to know:");
                    inputName = Console.ReadLine().Trim();
                
                    if (dict.TryGetValue(inputName, out inputGrade))
                    {
                        Console.Write("Grade: ");
                        Console.WriteLine(inputGrade);
                    } else
                    {
                        Console.WriteLine("Such a student does not exist");
                    }
                        Console.WriteLine("Enter the student's name ('-exit' for exit):");
                    inputName = Console.ReadLine().Trim();

                }

            }
        }

        private class Task3List
        {
            public void TaskLoop()
            {
                int inputValue;
                Console.WriteLine("Enter first number:");
                while (!int.TryParse(Console.ReadLine(), out inputValue))
                {
                    Console.WriteLine("Enter first number:");
                }
                Node node1 = new Node() { Value = inputValue };
                Console.WriteLine("Enter second number:");
                while (!int.TryParse(Console.ReadLine(), out inputValue))
                {
                    Console.WriteLine("Enter second number:");
                }
                Node node2 = new Node() { Value = inputValue };
                Console.WriteLine("Enter third number:");
                while (!int.TryParse(Console.ReadLine(), out inputValue))
                {
                    Console.WriteLine("Enter third number:");
                }
                Node node3 = new Node() { Value = inputValue };

                Console.WriteLine("The list contains:");
                node1.Next = node2;
                node2.Next = node3;
                Node next = node1;
                while (next != null)
                {
                    Console.WriteLine(next.Value);
                    next = next.Next;
                }

                Console.WriteLine("The list contains (reversed):");
                node3.Prev = node2;
                node2.Prev = node1;
                Node prev = node3;
                while (prev != null)
                {
                    Console.WriteLine(prev.Value);
                    prev = prev.Prev;

                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1,2 or 3 to check task 1,2 or 3:");
            int task;
            while (!int.TryParse(Console.ReadLine(), out task) || (task < 1 || task > 3))
            {
                Console.WriteLine("Enter 1,2 or 3 to check task 1,2 or 3:");
            }
            switch (task)
            {
                case 1:
                    CheckTaskFirst();
                    break;
                case 2:
                    CheckTaskSecond();
                    break;
                case 3:
                    CheckTaskThird();
                    break;
            }
        }

        private static void CheckTaskFirst()
        {
            Task1List listTask = new Task1List();
            listTask.TaskLoop();
        }
        private static void CheckTaskSecond()
        {
            Task2Dict DictTask = new Task2Dict();
            DictTask.TaskLoop();
        }
        private static void CheckTaskThird()
        {
            Task3List listTask = new Task3List();
            listTask.TaskLoop();
        }
    }
}

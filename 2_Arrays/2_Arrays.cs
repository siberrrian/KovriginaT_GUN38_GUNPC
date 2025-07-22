namespace _2_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] fib = new int[8] { 0, 1, 1, 2, 3, 5, 8, 13};

            string[] months = new string[12] {"January", "February", "March", "April", "May", "June",
                                             "July", "August", "September", "October", "November", "December"};
            
            int[,] array3 = new int[3, 3] {{     2,     3,     4 },
                                           {   2*2,   3*3,   4*4 },
                                           { 2*2*2, 3*3*3, 4*4*4 } };
            double[][] array4 = new double[3][] { new double[5] {1, 2, 3, 4, 5},
                                                  new double[2] {Math.E, Math.PI},
                                                  new double[4] {Math.Log10(1), Math.Log10(10), Math.Log10(100), Math.Log10(1000)}};
            int[] array = { 1, 2, 3, 4, 5 }; 
            int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };

            Array.Copy(array, array2, 3);
            Array.Resize(ref array, 10);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            

        }
    }
}

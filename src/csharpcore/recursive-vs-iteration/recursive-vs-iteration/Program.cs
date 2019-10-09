using System;
using System.Diagnostics;
using System.IO;

namespace recursive_vs_iteration
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch1 = new Stopwatch();
            Stopwatch stopWatch2 = new Stopwatch();

            string filepath = @"result.csv";
            using (StreamWriter sw = new StreamWriter(filepath, false))
            {
                string header = $"Index,Recursion,Interative";
                sw.WriteLine(header);
                for (int n = 0; n <= 50; n++)
                {
                    stopWatch1.Start();
                    long result = GetFibonacciNumberRecursively(n);
                    stopWatch1.Stop();
                    stopWatch2.Start();
                    long result2 = GetFibonacciNumberIteratively(n);
                    stopWatch2.Stop();

                    long ts1 = stopWatch1.ElapsedMilliseconds;
                    long ts2 = stopWatch2.ElapsedMilliseconds;

                    string row = $"{n},{ts1},{ts2}";
                    sw.WriteLine(row);

                    Console.Write($"n={n}".PadLeft(15).PadRight(15));
                    Console.Write($"{ts1}".PadLeft(15).PadRight(15));
                    Console.Write($"{ts2}".PadLeft(15).PadRight(15));
                    Console.WriteLine();
                }
            }
        }

        static long GetFibonacciNumberRecursively(int index)
        {
            if (index == 0)
                return 0;
            if (index == 1)
                return 1;
            return GetFibonacciNumberRecursively(index - 1) + GetFibonacciNumberRecursively(index - 2);
        }

        static long GetFibonacciNumberIteratively(int index)
        {
            long sum = 0;
            if (index == 0)
                return 0;
            if (index == 1)
                return 1;
            long f0 = 0;
            long f1 = 1;
            for(int i = 2; i <= index; i++)
            {
                sum = f0 + f1;
                f0 = f1;
                f1 = sum;
            }

            return sum;
        }
    }
}

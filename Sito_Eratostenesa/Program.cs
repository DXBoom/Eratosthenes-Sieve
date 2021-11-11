using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Sito_Eratostenesa
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch findTime = new Stopwatch();

            int n = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            findTime.Start();

            long mem = GC.GetTotalMemory(false);

            BitArray numbers = new BitArray(n);

            //erato
            for (int i = 2; i < numbers.Length; i++)
            {
                numbers[i] = true;
            }

            for (int j = 2; j * j <= numbers.Length; j++)
            {
                if (numbers[j] == true)
                {
                    for (int k = j * j; k < numbers.Length; k += j)
                    {
                        numbers[k] = false;
                    }
                }
            }
            //enderato
            findTime.Stop();

            mem = GC.GetTotalMemory(false) - mem;

            ulong sum = 0;

            for (int i = 2; i < n; ++i)
            {
                if (numbers[i] != false)
                    sum = sum + Convert.ToUInt32(i);
            }

            Console.WriteLine("Sum = " + sum);
            double ticks = findTime.ElapsedTicks;
            double milliseconds = (ticks / Stopwatch.Frequency) * 1000;
            Console.WriteLine("Total Time: {0} ", milliseconds);
            Console.WriteLine("Mem usage: " + mem / 1024 + "kb");
            Console.ReadLine();
        }
    }
}

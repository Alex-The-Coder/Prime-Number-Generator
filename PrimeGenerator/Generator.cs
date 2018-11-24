using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PrimeGenerator
{
    class Generator
    {
        static void Main(string[] args)
        {
            Console.Write("Up to what number would you like to generate primes? ");
            string input = Console.ReadLine();
            ulong max = Convert.ToUInt64(input);

            if (max <= 1)
            {
                Console.WriteLine("There are no primes below 2!");
                Console.ReadKey();
                return;
            }

            long time = SolveSieve(max);
            Console.WriteLine();
            Console.WriteLine("Time Elapsed: " + time + " Milliseconds");
            Console.ReadKey();
        }

        static long SolveSieve(ulong max)
        {
            var stopWatch = new Stopwatch();
            bool[] sieve = new bool[max + 1];
            ulong found = 0;

            stopWatch.Start();
            sieve[2] = true;
            found++;
            for (ulong i = 3; i <= max; i += 2)
            {
                sieve[i] = true;
            }
            for (ulong i = 3; i * i <= max; i += 2)
            {
                if (!sieve[i])
                {
                    continue;
                }
                found++;
                for (ulong j = i; (i * j) <= max; j++)
                {
                    ulong mult = i * j;
                    sieve[mult] = false;
                }
            }
            stopWatch.Stop();

            for (long prime = 0; prime < sieve.LongLength; prime++)
            {
                if (sieve[prime])
                {
                    Console.Write(prime + " ");
                }
            }

            return stopWatch.ElapsedMilliseconds;
        }
    }
}

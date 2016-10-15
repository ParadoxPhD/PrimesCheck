using System;
using System.Diagnostics;
using System.IO;
using System.Numerics;

namespace Prime
{
    public class Prime
    {
        const int C = 10601040;

        static Stopwatch watch = new Stopwatch();
        static int exp = 74207281;
        static BigInteger big = BigInteger.Pow(2, exp) - 1;
        static TextWriter tw = new StreamWriter("prime.txt"); // CurDir

        public static void Main()
        {
            watch.Start();
            for (int i = exp; true; ++i, ++exp)
                FindPrimes(i);
        }

        /// <summary>
        /// Find primes in an 32bit signed number. Finishes when
        /// the first non-prime has been found.<para/>
        /// Prints output to console and to prime.txt within the current
        /// directory.
        /// </summary>
        /// <param name="exp">Exponent.</param>
        /// <remarks>Decent performance.</remarks>
        private static void FindPrimes(double exp)
        {
            double div = Math.Floor(exp / C),
                exp1 = div,
                exp2 = exp - (exp1 * C),
                result = 0, r1, r2;
            long j = 3;

            for (long i = 3; i <= (big / j); i += 2, j += 2)
            {
                r1 = (Math.Pow(2, exp1) % i) * C;
                r2 = (Math.Pow(2, exp2) % i);
                result = (((r1 * r2) - 1) % i);
                if (result == 0)
                {
                    Console.WriteLine(exp + " is not prime.");
                    return;
                }
                Console.WriteLine(i + "is ga");
                result = 0;
            }
            tw.WriteLine(exp);
        }
    }
}
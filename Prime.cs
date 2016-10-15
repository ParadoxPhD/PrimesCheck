using System;
using System.IO;
using System.Numerics;
using System.Diagnostics;

namespace Prime
{
    public class Prime
    {
    	static Stopwatch watch = new Stopwatch();
        static int exp = 74207281;
        static BigInteger big = BigInteger.Pow(2, exp) - 1;
        static TextWriter tw = new StreamWriter(@"C:\CsStuff\Prime\prime.txt");

        public static void Main()
        {
        	watch.Start();
            for (int i = exp; true; i++)
            {
                exp++;
                primes(i);
            }
        }

        private static void primes(int exp)
        {
            int div = (int)Math.Floor((double)exp/10601040);
            int exp1 = div;
            int exp2 = exp - (exp1 * 10601040);
            long result = 0;
            long j = 3;

            for (long i = 3; i <= (big/j); i+=2)
            {
            	j+=2;
                long result1 = (long)(Math.Pow(2, exp1) % i) * 10601040;
                long result2 = (long)(Math.Pow(2, exp2) % i);
                result = (((result1 * result2) - 1) % i);
                if (result == 0)
                {
                    Console.WriteLine(exp + ", not prime.");
                    return;
                }
                Console.WriteLine(i);
                result = 0;
            }
            Console.WriteLine(exp);
            tw.WriteLine(exp);
        }
    }
}
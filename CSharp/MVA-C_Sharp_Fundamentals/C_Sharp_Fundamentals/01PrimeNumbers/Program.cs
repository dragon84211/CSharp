using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01PrimeNumbers {
    class Program {
        static List<int> arrOfPrimes = new List<int> { 2 };

        static void Main(string[] args) {
            Console.Write("Lowerbound: ");
            int lowerBound = int.Parse(Console.ReadLine()); //1024
            Console.Write("Upperbound: ");
            int upperBound = int.Parse(Console.ReadLine()); //1048576

            for (int i = 3; i < upperBound; i = i + 2) {
                if (isPrime(i)) {
                    arrOfPrimes.Add(i);
                }
            }

            printPrimes(lowerBound, upperBound);
        }

        static Boolean isPrime(int num) {
            int primeNumUpperLimit = (int)Math.Sqrt(num);

            for (int i = 0; arrOfPrimes[i] <= primeNumUpperLimit; i++) {
                if (num % arrOfPrimes[i] == 0) {
                    return false;
                }
            }
            return true;
        }

        static void printPrimes(int lowerBound, int upperBound) {
            int firstPrimeAfterLowerBound = int.Parse(arrOfPrimes.Where(o => o.CompareTo(lowerBound) == 1).FirstOrDefault().ToString());
            for (int i = arrOfPrimes.IndexOf(firstPrimeAfterLowerBound); i < arrOfPrimes.Count; i++) {
                Console.Write("{0}\t", arrOfPrimes[i]);
            }
            Console.WriteLine("\nTotal Number of Primes: {0}", arrOfPrimes.Count - arrOfPrimes.IndexOf(firstPrimeAfterLowerBound));
            Console.ReadLine();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int max_value = 0; //Why int and not long? Because you wouldn't want to calculate all prime numbers below 2^30 anyway.
            bool valid_input = false;
            while (valid_input == false)
            {
                Console.Write("Enter maximum value: ");
                string userinput = Console.ReadLine();
                valid_input = int.TryParse(userinput, out max_value);
                if (valid_input == false)
                {
                    Console.WriteLine("Please try again.");

                }
                if (max_value < 0)
                {
                    Console.WriteLine("Negative primes don't exist."); //They really don't.
                    valid_input = false;
                }
                if (max_value > 100000)
                    Console.WriteLine("Did you know there are around {0} primes below {1}?", Math.Round(max_value/(Math.Log(max_value)-1)), max_value); //To warn users of very long processing time.
            }

            IList<int> found_primes = new List<int>() { 1 }; //Best to start with 1. Is 0 a prime number? That's not within the scope of this project.
            for (int i = 1; i < max_value; i++)
            {
                bool isprime = true;
                foreach (int prime in found_primes)
                {
                    if (
                          (i % prime == 0)  //number besides 1 resulting in clean division
                          && (prime != 1)   //
                       )
                    {
                        isprime = false;
                    }
                    if (
                          (i > 100)					//This is meant to speed up testing of high numbers. I could start it earlier, but it doesn't matter all that much in speed.
                          && (prime > Math.Sqrt(i)) //for any two factors (y,z) such that x=y*z is true that y<=sqrt(x) and z>=sqrt(x)
                       )
                    {
                        break;
                    }
                }
                if (isprime)
                {
                    found_primes.Add(i);
                }

            }
            Console.WriteLine("Highest prime below {0}: {1}", max_value, found_primes[found_primes.Count - 1]); //I calculate all of them, but only show the highest. Yes, it's inefficient.
            Console.WriteLine("Number of primes below {0}: {1}", max_value, found_primes.Count); 				//That's why I add the exact count. All that processing power isn't completely wasted.
            Console.WriteLine("Press Enter to close this window.");
            Console.Read();
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using ProjectEuler.src.utilities;

namespace ProjectEuler
{
    public class Problem49 : ProblemBase
    {
        public Problem49()
        {
        }

        #region implemented abstract members of ProblemBase

        public override string Solve()
        {
            int max = 10000;
            bool[] primes = NumberUtilities.GetPrimes(max);
            List<int> primeIndices = new List<int>();
            Dictionary<int,int> indices = new Dictionary<int, int>();
            for (int i = 1000; i < max; i++)
            {
                if (primes[i])
                {
                    primeIndices.Add(i);
                    for (int j = 1; i+j < max; j++)
                    {
                        var c = i + j;
                        if (primes[c])
                        {
                            if (indices.ContainsKey(c-i))
                            {
                                indices[c-i]++;
                            } 
                            else
                            {
                                indices[c-i] = 1;
                            }
                        }
                    }
                }
            }
            var x = (from kvp in indices
                     orderby kvp.Value descending
                     select kvp).ToList();
            foreach (var item in x) {
                Console.WriteLine(item.Key + ", " + item.Value);
            }

            Console.WriteLine(primeIndices[primeIndices.Count - 2]);
            Console.WriteLine(primeIndices[primeIndices.Count - 1]);
            return string.Empty;
        }

        public override int ProblemNumber
        {
            get{ return 49; }
        }

        #endregion
    }
}


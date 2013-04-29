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
			int found = 0;
            for (int i = 1000; i < max; i++)
            {
                if (primes[i])
                {
                    primeIndices.Add(i);
                    for (int j = 1; i+j < max; j++)
                    {
                        var c = i + j;
                        if (c < max && primes[c])
                        {
                            if (c + j < max && primes[c + j] && ArePermutations(i, c, c+j))
                            {
								found++;
								if(found==2){
									return string.Format("{0}{1}{2}", i, c, c+j);
								}
                            }
                        }
                    }
                }
            }
            return string.Empty;
        }

        private bool ArePermutations(params int[] numbers)
        {
            bool result = true;
            if (numbers.Length > 0)
            {
				int temp = numbers[0];
                bool[] digits = new bool[10];
                int exp = (int)Math.Floor(Math.Log10(numbers[0]));
                int start = (int)Math.Pow(10, exp);
                while (exp >= 0)
                {
                    var currentDigit = (int)(temp / start);
					temp = temp % start;
                    digits[currentDigit] = true;
                    exp--;
					start = (int)Math.Pow (10,exp);
                }
                for (int i = 1; i < numbers.Length && result; i++)
                {
					bool[] currentDigits = new bool[10];
					temp = numbers[i];
					exp = (int)Math.Floor(Math.Log10(temp));
					start = (int)Math.Pow(10, exp);
					while (exp >= 0)
					{
						var currentDigit = temp / start;
						temp = temp % start;
						currentDigits[currentDigit] = true;
						if(!digits[currentDigit]){
							result = false;
							break;
						}
						exp--;
						start = (int)Math.Pow(10,exp);
					}
					for (int j = 0; j < 10; j++) {
						if(digits[j] != currentDigits[j]){
							result = false;
							break;
						}
                    }
                }
            }
            return result;
        }

        public override int ProblemNumber
        {
            get{ return 49; }
        }

        #endregion
    }
}


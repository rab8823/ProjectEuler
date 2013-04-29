using System;
using ProjectEuler.src.utilities;

namespace ProjectEuler
{
    public class Problem48 : ProblemBase
    {
        public Problem48()
        {
        }

        #region implemented abstract members of ProblemBase

        public override string Solve()
        {
            ulong m = 10000000000u;
            ulong sum = 0u;
            for (ulong i = 1; i <= 1000; i++)
            {
                sum += NumberUtilities.ModExp(i, i, m);
            }
            return sum.ToString();
        }

        public override int ProblemNumber
        {
            get { return 48; }
        }

        #endregion
    }
}


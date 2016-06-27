using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cryptonit.Algoritms
{
    class Euclid
    {

        public static long gcd(long a, long b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            // return gcd(b, b%a);
                return gcd(b, a%b);
        }

        public static long egcd(long a, long b, ref long x, ref long y)
        {
            if (a==0)
            {
                x = 0;
                y = 1;
                return b;
            }
            long x1 = 1;
            long y1 = 1;

            long d = egcd(b%a, a, ref x1 , ref y1);
            x = y1 - (b/a)*x1;
            y = x1;
            return d;
        }

    }
}

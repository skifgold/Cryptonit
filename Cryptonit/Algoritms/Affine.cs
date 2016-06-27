using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptonit.Algoritms
{
    class Affine
    {
        public static string AffineEncrypt(string text, int a, int b)
        {
            string cipherText = "";

            char[] chars = text.ToUpper().ToCharArray();

            foreach (char c in chars)
            {
                int x = Convert.ToInt32(c - 65);
                //int x = Convert.ToInt32(c-65);
                cipherText += Convert.ToChar(((a * x + b) % 26) + 65);
                //cipherText += Convert.ToChar(((a * x + b) % 33)+65);
            }

            return cipherText;
        }

        public  static string AffineDecrypt(string cipherText, int a, int b)
        {
            string text = "";

            int aInverse = MultiplicativeInverse(a);

            char[] chars = cipherText.ToUpper().ToCharArray();

            foreach (char c in chars)
            {
                //int x = Convert.ToInt32(c-65);
                int x = Convert.ToInt32(c - 65);
                if (x - b < 0) x = Convert.ToInt32(x) + 26;
                //if (x - b < 0) x = Convert.ToInt32(x) +33;
                text += Convert.ToChar(((aInverse * (x - b)) % 26) + 65);
                //text += Convert.ToChar(((aInverse * (x - b)) % 33)+65);
            }

            return text;
        }

        public static int MultiplicativeInverse(int a)
        {
            for (int x = 1; x < 27; x++)
            {
                if ((a*x)%26==1)
                {
                    return x;
                }
            }

            throw new Exception("No multiplicative inverse found!");
        }
    }
}

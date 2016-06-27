using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptonit.Algoritms
{
    class Cessar
    {
        


        public static string CessarEncrypt(string text, int key)
        {
            string chipher = "";




            string alfE = "abcdefghijklmnopqrstuvwxyz. ";
            string alfR = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

            int alphabet = alfE.Length;

            char[] chars = text.ToLower().ToCharArray();

            foreach (var symb in chars)
            {
                for (int i = 0; i < alphabet; i++)
                {
                    if (symb == alfE[i])
                    {
                        int position = (i + key)%26;

                        chipher += alfE[position];
                    }
                    
                }
            }

            return chipher;
        }




        public static string CessarDecrypt(string chipher, int key)
        {
            string text = "";

           

            string alfE = "abcdefghijklmnopqrstuvwxyz. ";
            string alfR = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

            int alphabet = alfE.Length;

            char[] chars = chipher.ToLower().ToCharArray();

            foreach (var symb in chars)
            {
                for (int i = 0; i < alphabet; i++)
                {
                    if (symb == alfE[i])
                    {
                        int position = (i - key)%26;

                        if (position<0)
                            position += alphabet;
                        

                        text += alfE[position];
                    }
                }
            }

        
            
            return text;

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyExcelLAB
{
    class _26BasedSystem
    {
        public static string To26System(int i)
        {
            int k = 0;
            int[] Arr = new int[50];
            while(i>25)
            {
                Arr[k] = i / 26 - 1;
                k++;
                i = i % 26;
            }
            Arr[k] = i;
            string res = "";
            for (int j = 0; j <= k;j++)
            {
                res += ((char)('A' + Arr[j])).ToString();
            }
            return res;
        }
        public static int[] From26Sys(string index)
        {
            int[] nums = new int[2];
            StringBuilder first_part = new StringBuilder();
            int letter_index = 0;
            foreach (char c in index)
            {
                if (Char.IsLetter(c))
                {
                    first_part.Append(c);
                    letter_index++;
                    continue;
                }

                string first = first_part.ToString();
                char[] charArray = first.ToCharArray();
                int len = charArray.Length;
                int res = 0;
                for (int i = len - 2; i >= 0; --i)
                {
                    res += (((int)charArray[i] - (int)'A') + 1) * Convert.ToInt32(Math.Pow(26, len - i - 1));
                }
                res += ((int)charArray[len - 1] - (int)'A');
                nums[0] = res;
                break;
            }
            nums[1] = Convert.ToInt32(index.Substring(letter_index));
            return nums;
        }

    }
}

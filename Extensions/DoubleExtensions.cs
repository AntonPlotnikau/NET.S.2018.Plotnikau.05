using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class DoubleExtensions
    {
        public static string ToBinaryForm(this double source)
        {
            long[] array = new long[64];
            if (source < 0)
            {
                array[0] = 1;
                source *= -1;
            }

            long integerPart = (long)source;
            double fractionalPart = source - integerPart;

            long[] integerArray = ToBinaryArray(integerPart);
            long[] fractionalArray = ToBinaryArray(fractionalPart);

            var list = new List<long>();
            list.AddRange(integerArray);
            list.AddRange(fractionalArray);

            for (int i = 0; i < list.Capacity && list[i] != 1; i++)
            {
                list.Remove(0);
            }

            if (list.Capacity > 0)
            {
                list.Remove(1);
            }

            for (int i = 12, j = 0; i < list.Capacity && i < 63; i++, j++) 
            {
                array[i] = list[j];
            }

            int E = 0;

            if (integerArray.Length == 1 && integerArray[0] == 0)
            {
                for (int i = 0; i < 51 || fractionalArray[i] != 1; i++) 
                {
                    E--;
                }

                E--;
            }
            else
            {
                E = integerArray.Length - 1;
            }

            long[] arrayE = ToBinaryArray(1023 + E);

            for(int i = 0; i < arrayE.Length; i++)
            {
                array[i+1] = arrayE[i];
            }

            string result = "";
            for(int i = 0; i < array.Length; i++)
            {
                if(array[i]==1)
                {
                    result += "1";
                }
                else
                {
                    result += "0";
                }
            }

            return result;
        }

        private static long[] ToBinaryArray(long source)
        {
            var list = new List<long>();
            do
            {
                list.Add(source % 2);
                source /= 2;
            }
            while (source != 0);

            list.Reverse();

            return list.ToArray();
        }

        private static long[] ToBinaryArray(double source)
        {
            long[] array = new long[52];
            for(int i = 0; i < 52; i++)
            {
                source *= 2 - (int)source;
                array[i] = (int)(source);
                source -= (int)source;
            }

            return array;
        }
    }
}

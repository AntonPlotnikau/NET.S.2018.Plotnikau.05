using System;

namespace Extensions
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// To the decimal form.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="systemIndex">Index of the numerical system.</param>
        /// <returns>decimal form of number</returns>
        /// <exception cref="ArgumentOutOfRangeException">systemIndex less than two or more than 16</exception>
        /// <exception cref="ArgumentNullException">source string is null</exception>
        /// <exception cref="ArgumentException">source string is not fit to current systemIndex</exception>
        /// <exception cref="OverflowException">result is more than max value of unsigned integer</exception>
        public static long ToDecimalForm(this string source, int systemIndex)
        {
            if (systemIndex < 2 || systemIndex > 16)
            {
                throw new ArgumentOutOfRangeException(nameof(systemIndex));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            long result = 0;
            char[] array = source.ToCharArray();

            for (int i = array.Length - 1; i >= 0; i--) 
            {
                int temp = array[i] - '0';
                if (array[i] == 'A' || array[i] == 'a')
                {
                    temp = 10;
                }

                if (array[i] == 'B' || array[i] == 'b')
                {
                    temp = 11;
                }

                if (array[i] == 'C' || array[i] == 'c')
                {
                    temp = 12;
                }

                if (array[i] == 'D' || array[i] == 'd')
                {
                    temp = 13;
                }

                if (array[i] == 'E' || array[i] == 'e')
                {
                    temp = 14;
                }

                if (array[i] == 'F' || array[i] == 'f')
                {
                    temp = 15;
                }

                if (temp >= systemIndex)
                {
                    throw new ArgumentException(nameof(source));
                }

                result += temp * (long)Math.Pow(systemIndex, array.Length - i - 1);
            }

            if (result > uint.MaxValue)
            {
                throw new OverflowException(nameof(result));
            }

            return result;
        }
    }
}

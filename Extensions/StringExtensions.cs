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
        /// <param name="source">The source.</param>
        /// <param name="notation">Notation object.</param>
        /// <returns>decimal form of number</returns>
        /// <exception cref="ArgumentNullException">source is null</exception>
        public static int ToDecimalForm(this string source, Notation notation)
        {
            int index = notation.NotationBase;

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int result = 0;
            char[] array = source.ToCharArray();

            for (int i = array.Length - 1; i >= 0; i--) 
            {
                int temp = notation.DigitToDecimal(array[i]);

                checked
                {
                    result += temp * (int)Math.Pow(index, array.Length - i - 1);
                }
            }

            return result;
        }

        /// <summary>
        /// Notation system class
        /// </summary>
        public class Notation
        {
            /// <summary>
            /// The default base of notation
            /// </summary>
            private const int DefaultBase = 2;

            /// <summary>
            /// The left border of Notation Base
            /// </summary>
            private const int LeftBorder = 2;

            /// <summary>
            /// The right border of Notation Base
            /// </summary>
            private const int RightBorder = 16;

            /// <summary>
            /// The alphabet of Notation digits
            /// </summary>
            private const string Alphabet = "0123456789ABCDEF";

            /// <summary>
            /// Initializes a new instance of the <see cref="Notation"/> class.
            /// </summary>
            public Notation()
            {
                this.NotationBase = DefaultBase;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Notation"/> class.
            /// </summary>
            /// <param name="sourceBase">The source base.</param>
            /// <exception cref="ArgumentOutOfRangeException">sourceBase is out of range of the notation borders</exception>
            public Notation(int sourceBase)
            {
                if (sourceBase < LeftBorder || sourceBase > RightBorder)
                {
                    throw new ArgumentOutOfRangeException(nameof(sourceBase));
                }

                this.NotationBase = sourceBase;
            }

            /// <summary>
            /// Gets the notation base.
            /// </summary>
            /// <value>
            /// The notation base.
            /// </value>
            public int NotationBase { get; }

            /// <summary>
            /// Digits to decimal.
            /// </summary>
            /// <param name="digit">The digit.</param>
            /// <returns>digit in the decimal representation</returns>
            /// <exception cref="ArgumentException">Current notation is not contain this digit</exception>
            public int DigitToDecimal(char digit)
            {
                int result = Alphabet.IndexOf(char.ToUpper(digit));

                if (result >= this.NotationBase)
                {
                    throw new ArgumentException(nameof(digit));
                }

                return result;
            }
        }
    }
}

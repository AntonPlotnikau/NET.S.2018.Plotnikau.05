using System.Runtime.InteropServices;

namespace Extensions
{
    /// <summary>
    /// Double extensions
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// The bits in byte
        /// </summary>
        private const int BITS_IN_BYTE = 8;

        /// <summary>
        /// The bits in double
        /// </summary>
        private const int BITS_IN_DOUBLE = 8 * BITS_IN_BYTE;

        /// <summary>
        /// Double to binary string.
        /// </summary>
        /// <param name="number">Source double number.</param>
        /// <returns>string that represents double bits</returns>
        public static string DoubleToBinaryString(this double number)
        {
            DoubleToLongStruct bytes = new DoubleToLongStruct();
            bytes.Double64bits = number;
            string binaryString = string.Empty;
            long bits = bytes.Long64bits;
            for (int n = 0; n < BITS_IN_DOUBLE; n++) 
            {
                if ((bits & 1) == 1) 
                {
                    binaryString = "1" + binaryString;
                }
                else
                {
                    binaryString = "0" + binaryString;
                }

                bits >>= 1;
            }

            return binaryString;
        }

        /// <summary>
        /// double to long bits cast
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct DoubleToLongStruct
        {
            /// <summary>
            /// The long64bits
            /// </summary>
            [FieldOffset(0)]
            private readonly long long64bits;

            /// <summary>
            /// The double64bits
            /// </summary>
            [FieldOffset(0)]
            private double double64bits;

            /// <summary>
            /// Gets the long64bits.
            /// </summary>
            /// <value>
            /// The long64bits.
            /// </value>
            public long Long64bits
            {
                get
                {
                    return this.long64bits;
                }
            }

            /// <summary>
            /// Sets the double64bits.
            /// </summary>
            /// <value>
            /// The double64bits.
            /// </value>
            public double Double64bits
            {
                set
                {
                    this.double64bits = value;
                }
            }
        }
    }
}

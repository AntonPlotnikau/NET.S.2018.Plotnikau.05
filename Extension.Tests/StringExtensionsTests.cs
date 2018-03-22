using System;
using Extensions;
using NUnit.Framework;

namespace Extension.Tests
{
    [TestFixture]
    class StringExtensionsTests
    {
        [Test]
        [TestCase("0110111101100001100001010111111", 2, ExpectedResult = 934331071)]
        [TestCase("01101111011001100001010111111", 2, ExpectedResult = 233620159)]
        [TestCase("11101101111011001100001010111111", 2, ExpectedResult = 3991716543)]
        [TestCase("1AeF101", 16, ExpectedResult = 28242177)]
        [TestCase("1ACB67", 16, ExpectedResult = 1756007)]
        [TestCase("764241", 8, ExpectedResult = 256161)]
        [TestCase("10", 5, ExpectedResult = 5)]
        public static long ToDecimalFormTests(string source, int systemIndex)
            => source.ToDecimalForm(systemIndex);

        [Test]
        [TestCase("1AeF101", 2)]
        [TestCase("SA123", 2)]
        public static void ToDecimalFormArgumentException(string source, int systemIndex)
            => Assert.Throws<ArgumentException>(() => source.ToDecimalForm(systemIndex));

        [Test]
        [TestCase("111111111111111111111111111111111", 2)]
        public static void ToDecimalFormOverflowException(string source, int systemIndex)
            => Assert.Throws<OverflowException>(() => source.ToDecimalForm(systemIndex));
    }
}

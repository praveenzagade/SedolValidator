using MnG.SedolChecker.Implementations;
using MnG.SedolChecker.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;

namespace MnG.SedolChecker.NUnit3.Tests
{
    internal class InputCheckSumValidator_Tests
    {
        private Dictionary<int, int> _WeightingFactor = new Dictionary<int, int>()
            {
                { 1, 1},
                { 2, 3},
                { 3, 1},
                { 4, 7},
                { 5, 3},
                { 6, 9},
                { 7, 1}
            };

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("      ")]
        [TestCase("       ")]
        [TestCase("        ")]
        [TestCase("         ")]
        [TestCase("12")]
        [TestCase("12     ")]
        [TestCase("     12")]
        [TestCase("123456789")]
        [TestCase("1234567")]
        [TestCase("0709954")]
        [TestCase("B0YBKJ7")]
        [TestCase("9123451")]
        [TestCase("9ABCDE8")]
        [TestCase("9123_51")]
        [TestCase("VA.CDE8")]
        [TestCase("9123458")]
        [TestCase("9ABCDE1")]
        public void GetCheckSum_MultipleInputs(string inputString)
        {
            //Arrange
            IValueProvider alphabetCodeValueProvider = new AlphabetCodeValueProvider();
            IValueProvider codeValueProvider = new CodeValueProvider(alphabetCodeValueProvider);
            IWeightingFactorProvider weightingFactorProvider = new HardCodedWeightingFactorProvider();
            ICheckSumProvider testSubject = new CheckSumProvider(codeValueProvider,
                                                                 weightingFactorProvider);

            int expectedValue = GetExpectedCheckSum(inputString);

            ////Act
            int actualResult = testSubject.GetCheckSum(inputString);

            ////Assert

            Assert.AreEqual(expectedValue, actualResult);
        }

        private int GetExpectedCheckSum(string source)
        {
            int retValue = 0;

            source = source?.Trim().ToUpperInvariant();
            if (!string.IsNullOrWhiteSpace(source))
            {
                int index = 0;
                foreach (char chr in source)
                {
                    index++;
                    retValue += GetCodeValue(chr) * _WeightingFactor[index];
                    if (index == 6) break;
                }
            }
            return retValue;
        }

        private int GetCodeValue(char source)
        {
            int retValue = 0;
            if (char.IsNumber(source))
            {
                if (!int.TryParse(char.ToString(source), out retValue))
                {
                    retValue = 0;
                }
            }
            else if (char.IsLetter(source))
            {
                retValue = char.ToUpper(source) - ('A' - 1) + 9;
            }
            return retValue;
        }
    }
}
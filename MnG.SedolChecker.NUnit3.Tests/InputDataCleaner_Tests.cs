using MnG.SedolChecker.Implementations;
using MnG.SedolChecker.Interfaces;
using NUnit.Framework;

namespace MnG.SedolChecker.NUnit3.Tests
{
    public class InputDataCleaner_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(null, null)]
        [TestCase("", "")]
        [TestCase("  ", "")]
        [TestCase("      ", "")]
        [TestCase("       ", "")]
        [TestCase("        ", "")]
        [TestCase("         ", "")]
        [TestCase("12", "12")]
        [TestCase("12     ", "12")]
        [TestCase("     12", "12")]
        [TestCase("123456789", "123456789")]
        [TestCase("1234567", "1234567")]
        [TestCase("B0YBKJ7", "B0YBKJ7")]
        [TestCase("9ABCDE8", "9ABCDE8")]
        [TestCase("9123_51", "9123_51")]
        [TestCase("VA.CDE8", "VA.CDE8")]
        [TestCase("9ABCDE1", "9ABCDE1")]
        [TestCase("9abcde1", "9ABCDE1")]
        [TestCase("Ab", "AB")]
        [TestCase("ab     ", "AB")]
        [TestCase("     aB", "AB")]
        public void Clean_MultipleInputs(string inputString,
                                         string expectedResult)
        {
            //Arrange
            IDataCleaner testSubject = new InputDataCleaner();

            //Act
            string actualResult = testSubject.Clean(inputString);

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
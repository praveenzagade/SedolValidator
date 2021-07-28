using MnG.SedolChecker.Implementations;
using MnG.SedolChecker.Interfaces;
using NUnit.Framework;

namespace MnG.SedolChecker.NUnit3.Tests
{
    internal class InputContentValidator_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase("  ", false)]
        [TestCase("      ", false)]
        [TestCase("       ", false)]
        [TestCase("        ", false)]
        [TestCase("         ", false)]
        [TestCase("12", true)]
        [TestCase("12     ", false)]
        [TestCase("     12", false)]
        [TestCase("123456789", true)]
        [TestCase("1234567", true)]
        [TestCase("0709954", true)]
        [TestCase("B0YBKJ7", true)]
        [TestCase("9123451", true)]
        [TestCase("9ABCDE8", true)]
        [TestCase("9123_51", false)]
        [TestCase("VA.CDE8", false)]
        [TestCase("9123458", true)]
        [TestCase("9ABCDE1", true)]
        public void IsValid_MultipleInputs(string inputString,
                                           bool isValid)
        {
            //Arrange
            IInputValidator testSubject = new InputContentValidator();

            //Act
            bool actualResult = testSubject.IsValid(inputString);

            //Assert
            Assert.AreEqual(isValid, actualResult);
        }
    }
}
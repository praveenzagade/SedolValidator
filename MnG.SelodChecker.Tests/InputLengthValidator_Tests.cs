using MnG.SedolChecker.Implementations;
using MnG.SedolChecker.Interfaces;
using NUnit.Framework;

namespace MnG.SelodChecker.Tests
{
    public class InputLengthValidator_Tests
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
        [TestCase("12", false)]
        [TestCase("12     ", true)]
        [TestCase("     12", true)]
        [TestCase("123456789", false)]
        [TestCase("1234567", true)]
        [TestCase("0709954", true)]
        [TestCase("B0YBKJ7", true)]
        [TestCase("9123451", true)]
        [TestCase("9ABCDE8", true)]
        [TestCase("9123_51", true)]
        [TestCase("VA.CDE8", true)]
        [TestCase("9123458", true)]
        [TestCase("9ABCDE1", true)]
        public void IsValid_MultipleInputs(string inputString,
                                           bool isValid)
        {
            //Arrange
            IInputValidator testSubject = new InputLengthValidator();

            //Act
            bool actualResult = testSubject.IsValid(inputString);

            //Assert
            Assert.AreEqual(isValid, actualResult);

            //Assert.That(() => testSubject.IsValid(inputString), Throws.ArgumentException);
        }
    }
}
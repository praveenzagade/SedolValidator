using MnG.SedolChecker.Implementations;
using MnG.SedolChecker.Interfaces;
using NUnit.Framework;

namespace MnG.SedolChecker.NUnit3.Tests
{
    internal class UserDefinedSedolValidator_Tests
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
        [TestCase("12     ", false)]
        [TestCase("     12", false)]
        [TestCase("123456789", false)]
        [TestCase("1234567", false)]
        [TestCase("0709954", false)]
        [TestCase("B0YBKJ7", false)]
        [TestCase("9123451", true)]
        [TestCase("9ABCDE8", true)]
        [TestCase("9123_51", true)]
        [TestCase("VA.CDE8", false)]
        [TestCase("9123458", true)]
        [TestCase("9ABCDE1", true)]
        public void Validate_MultipleInputs(string inputString,
                                                 bool isUserDefined)
        {
            //Arrange
            IInputValidator testSubject = new UserDefinedSedolValidator();

            //Act
            bool actualResult = testSubject.IsValid(inputString);

            //Assert
            Assert.AreEqual(isUserDefined, actualResult);
        }
    }
}
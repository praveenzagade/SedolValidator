using MnG.SedolChecker.Common;
using MnG.SedolChecker.Implementations;
using MnG.SedolChecker.Interfaces;
using NUnit.Framework;

namespace MnG.SelodChecker.Tests
{
    public class ImplementedSedolValidator_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(null, false, false, ErrorMessages.InputStringNot7CharLong)]
        [TestCase("", false, false, ErrorMessages.InputStringNot7CharLong)]
        [TestCase("  ", false, false, ErrorMessages.InputStringNot7CharLong)]
        [TestCase("      ", false, false, ErrorMessages.InputStringNot7CharLong)]
        [TestCase("       ", false, false, ErrorMessages.InputStringNot7CharLong)]
        [TestCase("        ", false, false, ErrorMessages.InputStringNot7CharLong)]
        [TestCase("         ", false, false, ErrorMessages.InputStringNot7CharLong)]
        [TestCase("12", false, false, ErrorMessages.InputStringNot7CharLong)]
        [TestCase("12     ", false, false, ErrorMessages.InputStringNot7CharLong)]
        [TestCase("     12", false, false, ErrorMessages.InputStringNot7CharLong)]
        [TestCase("123456789", false, false, ErrorMessages.InputStringNot7CharLong)]
        [TestCase("1234567", false, false, ErrorMessages.CheckSumError)]
        [TestCase("0709954", true, false, null)]
        [TestCase("B0YBKJ7", true, false, null)]
        [TestCase("9123451", false, true, ErrorMessages.CheckSumError)]
        [TestCase("9ABCDE8", false, true, ErrorMessages.CheckSumError)]
        [TestCase("9123_51", false, false, ErrorMessages.ContainsInvalidChar)]
        [TestCase("VA.CDE8", false, false, ErrorMessages.ContainsInvalidChar)]
        [TestCase("9123458", true, true, null)]
        [TestCase("9ABCDE1", true, true, null)]
        public void ValidateSedol_MultipleInputs(string inputString,
                                                 bool isValidSedol,
                                                 bool isUserDefined,
                                                 string validationDetails)
        {
            //Arrange
            ISedolValidator testSubject = new ImplementedSedolValidator();

            //Act
            ISedolValidationResult actualResult = testSubject.ValidateSedol(inputString);

            ////Assert

            Assert.That(actualResult.InputString, Is.EqualTo(inputString));
            Assert.AreEqual(isValidSedol, actualResult.IsValidSedol);
            Assert.AreEqual(isUserDefined, actualResult.IsUserDefined);
            Assert.That(actualResult.ValidationDetails, Is.EqualTo(validationDetails));
        }
    }
}
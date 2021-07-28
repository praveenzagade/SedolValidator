using MnG.SedolChecker.Implementations;
using MnG.SedolChecker.Interfaces;
using NUnit.Framework;

namespace MnG.SedolChecker.NUnit3.Tests
{
    public class AlphabetCodeValueProvider_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase('A', 10)]
        [TestCase('b', 11)]
        [TestCase('C', 12)]
        [TestCase('d', 13)]
        [TestCase('E', 14)]
        [TestCase('f', 15)]
        [TestCase('G', 16)]
        [TestCase('h', 17)]
        [TestCase('W', 32)]
        [TestCase('X', 33)]
        [TestCase('y', 34)]
        [TestCase('Z', 35)]
        [TestCase(' ', 0)]
        [TestCase('.', 0)]
        [TestCase('\\', 0)]
        [TestCase('#', 0)]
        public void GetAlphabetValue_MultipleInputs(char source,
                                                    int value)
        {
            //Arrange
            IValueProvider testSubject = new AlphabetCodeValueProvider();

            //Act
            int result = testSubject.GetValue(source);

            //Assert
            Assert.AreEqual(value, result);
        }
    }
}
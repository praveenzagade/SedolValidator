using MnG.SedolChecker.Implementations;
using MnG.SedolChecker.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;

namespace MnG.SelodChecker.Tests
{
    public class HardCodedWeightingFactorProvider_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetWeightingFactor()
        {
            //Arrange
            IWeightingFactorProvider testSubject = new HardCodedWeightingFactorProvider();
            Dictionary<int, int> expectedResult = new Dictionary<int, int>()
            {
                { 1, 1},
                { 2, 3},
                { 3, 1},
                { 4, 7},
                { 5, 3},
                { 6, 9},
                { 7, 1}
            };
            //Act
            Dictionary<int, int> result = testSubject.GetWeightingFactor();

            //Assert
            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}
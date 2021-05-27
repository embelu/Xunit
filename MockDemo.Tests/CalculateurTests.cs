using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MockDemo.Tests
{
    public class CalculateurTests
    {
        /// <summary>
        /// Cas Classique avec InlineData
        /// </summary>
        [Theory]
        [InlineData(1,2,3)]
        [InlineData(1, 7, 8)]
        public void CalculSumOfParameter_WhenParamTheory_ThenReturnOk(int value1, int value2, int expected)
        {
            var calculateur = new Calculateur();
            var result = calculateur.Add(value1, value2);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Cas avec une énumération.
        /// </summary>
        [Theory]
        [ClassData(typeof(CalculateurTestData))]
        public void CalculSumOfParameter_WhenParamTheoryClassData_ThenReturnOk (int value1, int value2, int expected)
        {
            var calculateur = new Calculateur();
            var result = calculateur.Add(value1, value2);

            Assert.Equal(expected, result);
        }
    }
}

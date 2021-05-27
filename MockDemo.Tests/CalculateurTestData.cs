using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MockDemo.Tests
{
    public class CalculateurTestData : IEnumerable<Object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, 3 };   // Permet de faire un enumerateur
            yield return new object[] { -4, -6, -10};
            yield return new object[] { int.MinValue, -1, int.MaxValue};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    }
}

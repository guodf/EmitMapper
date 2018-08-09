using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EmitMapperTests
{
    class CustomAssert
    {
        public static void AreEqual(ICollection expected, ICollection actual)
        {
            Assert.Equal(expected.Count, actual.Count);
            IEnumerator enumExpected = expected.GetEnumerator();
            IEnumerator enumActual = actual.GetEnumerator();
            while (enumExpected.MoveNext() && enumActual.MoveNext())
            {
                Assert.Equal(enumExpected.Current, enumActual.Current);
            }
        }

		public static void AreEqualEnum<T>(IEnumerable<T> expected, IEnumerable<T> actual)
		{
			Assert.Equal(expected.Count(), actual.Count());
			IEnumerator enumExpected = expected.GetEnumerator();
			IEnumerator enumActual = actual.GetEnumerator();
			while (enumExpected.MoveNext() && enumActual.MoveNext())
			{
				Assert.Equal(enumExpected.Current, enumActual.Current);
			}
		}
   }
}
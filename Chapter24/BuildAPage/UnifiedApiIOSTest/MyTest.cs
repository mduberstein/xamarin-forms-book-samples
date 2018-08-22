
using System;
using NUnit.Framework;

namespace UnifiedApiIOSTest {
	[TestFixture]
	public class MyTest {
		[Test]
		public void Pass() {
			Assert.True(true);
		}

		[Test]
		public void Fail() {
			Assert.False(true);
		}

		[Test]
		[Ignore("another time")]
		public void Ignore() {
			Assert.True(false);
		}

		[TestCase(0.21, "0.21")]
		public void CompareDoubleAndStringTest(double valDouble, string valString){
			string valToString = valDouble.ToString();
			Assert.IsTrue(valToString.Equals(valString, StringComparison.InvariantCultureIgnoreCase));

		}
	}
}

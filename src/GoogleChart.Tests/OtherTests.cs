using System;
using NUnit.Framework;

namespace McGiv.GoogleCharts.Tests
{
	[TestFixture]
	public class Class1
	{


		
		[TestCase("01 Jan 2010", "20 Mar 2010", 31+28+20)]
		public void TestDateCount(string from, string to, double count)
		{
			var a = AxisHelper.GetDateAxis(Position.Bottom, DateTime.Parse(from), DateTime.Parse(to));

			Assert.AreEqual(count, a.End);
		}


	}
}

using System;
using NUnit.Framework;

namespace McGiv.GoogleCharts.Tests
{

	[TestFixture]
	public class LineChartTests
	{


		/// <summary>
		/// Generates a test line chart URL
		/// </summary>
		[Test]
		public void GenerateLineLine()
		{
			var url = GoogleCharts.LineChart()
				.Size(900, 300)
				.Title("Test Line Chart")
				.AddSeries(new double[] { 40, 60, 60, 45, 47, 75, 70, 72 }, "ff0000", "Completed")
				.AddSeries(new double[] { 27, 25, 60, 31, 25, 39, 25, 31, 26, 28, 80, 28, 27, 31, 27, 29, 26, 35, 70, 25 }, "0077CC", "Recorded")
				.AddAxis(Position.Left, 0, 356, 5)
				.AddAxis(Position.Left, 0, 100, null, new[] { new AxisLabel { Text = "Member Count", Position = 50 } })
				.AddAxis(AxisHelper.GetDateAxis(Position.Bottom, DateTime.Parse("01 Jan 2010"), DateTime.Now))
				.ToString();

			Console.WriteLine(url);
		}

	}
}

using System;
using NUnit.Framework;

namespace McGiv.GoogleCharts.Tests
{

	[TestFixture]
	public class BarChartTests
	{


		/// <summary>
		/// Generates a URL that displays a bar chart
		/// </summary>
		[Test]
		public void TestBar()
		{
			var url = GoogleCharts.BarChart()
				.Size(850, 300)
				.BarSpacing(5)
				.GroupSpacing(20)
				.Title("Test Bar Chart")
				.AddSeries(new double[] { 40, 60, 60, 45, 47, 75, 70, 72, 23, 45 }, "ff0000", "Completed")
				.AddSeries(new double[] { 40, 60, 60, 45, 47, 75, 70, 72, 56, 34 }, "0077CC", "Recorded")
				.AddAxis(Position.Bottom, 0, 100, 5, new[]
				{
					new AxisLabel{Text="0-9%", Position=5},
					new AxisLabel{Text="10-19%", Position=15},
					new AxisLabel{Text="20-29%", Position=25},
					new AxisLabel{Text="30-39%", Position=35},
					new AxisLabel{Text="40-49%", Position=45},
					new AxisLabel{Text="50-59%", Position=55},
					new AxisLabel{Text="60-69%", Position=65},
					new AxisLabel{Text="70-79%", Position=75},
					new AxisLabel{Text="80-89%", Position=85},
					new AxisLabel{Text="90-100%", Position=95},
				}
				)
				.AddAxis(Position.Left, 0, 100, 5)
				.AddAxis(Position.Left, 0, 100, null, new[] { new AxisLabel { Text = "Members", Position = 50 } })
				.ToString();

			Console.WriteLine(url);
		}
	}
}

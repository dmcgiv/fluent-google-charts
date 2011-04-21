
using System.Collections.Generic;
using System.Linq;


namespace McGiv.GoogleCharts
{
	//public class GoogleChart
	//{

	//}

	public enum GoogleChartDimension
	{
		Chart2D,
		Chart3D

	}

	public static class En
	{
		public static IEnumerable<double> ToPercentages(this IEnumerable<double> source)
		{

			double sum = source.Sum();

			if (sum == 0)
			{
				// todo
				return null;
			}

			sum = 100 / sum;

			return source.Select(i => i * sum);

		}

	}


	public static class GoogleCharts
	{
		public static GooglePieChart PieChart()
		{
			return new GooglePieChart();
		}

		public static GoogleLineChart LineChart()
		{
			return new GoogleLineChart();
		}

		public static GoogleBarChart BarChart()
		{
			return new GoogleBarChart();
		}

	}


}
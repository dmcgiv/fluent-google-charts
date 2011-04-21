
using System.Collections.Generic;


namespace McGiv.GoogleCharts
{
	public class GoogleLineChart : MultiSeriesBase<GoogleLineChart>
	{

		private bool _sparklines;



		public new string ToString()
		{
			var sb = GetBuilder();

			// type
			sb.Append("&cht=");

			if (_sparklines)
			{
				sb.Append("ls");
			}
			else
			{
				sb.Append("lc");
			}



			return sb.ToString();

		}

		public GoogleLineChart HideSparkLines()
		{
			_sparklines = true;

			return this;
		}









	}



	/// <summary>
	/// Repersents a single line in the graph.
	/// </summary>
	public class Series
	{

		/// <summary>
		/// The data values for the line.
		/// </summary>
		public IEnumerable<double> Data { get; set; }


		/// <summary>
		/// The colour of the line.
		/// </summary>
		public string ColourHex { get; set; }


		/// <summary>
		/// The name of the series that appears in the legend
		/// </summary>
		public string Legend { get; set; }


		/// <summary>
		/// If true the line will be dashed otherwise it will be solid.
		/// </summary>
		public bool Dashed { get; set; }

		public double? Min { get; set; }

		public double? Max { get; set; }
	}



	public class Axis
	{

		public Axis()
		{
			Position = Position.Bottom;
			Labels = new List<AxisLabel>();
		}

		public Position Position { get; set; }


		/// <summary>
		/// Number of pixels the length of the tick mark should be.
		/// If null no tick mark is shown/
		/// </summary>
		public int? TickMarkLength { get; set; }


		public IList<AxisLabel> Labels { get; set; }



		/// <summary>
		/// If null and no labels are supplied then default value is 0
		/// </summary>
		public double? Start { get; set; }


		/// <summary>
		/// If null and no labels are supplied then default value is 100
		/// </summary>
		public double? End { get; set; }

	}

	public class AxisLabel
	{

		/// <summary>
		/// The text of the label.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Value relative to range
		/// If null labels and positioned in order in regurlar spacing.
		/// </summary>
		public double? Position { get; set; }
	}
}
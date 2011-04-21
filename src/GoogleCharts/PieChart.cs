using System;
using System.Collections.Generic;
using System.Web;

namespace McGiv.GoogleCharts
{
	public class GooglePieChart : BaseGoogleChart<GooglePieChart>
	{
		IEnumerable<string> _legends;
		IEnumerable<string> _labels;
		IEnumerable<string> _colours;
		IEnumerable<double> _data;
		GoogleChartDimension _type;





		public new string ToString()
		{
			var sb = base.GetBuilder();


			// type
			sb.Append("&cht=");

			switch (_type)
			{
				case GoogleChartDimension.Chart2D:
					{
						sb.Append('p');
						break;
					}

				case GoogleChartDimension.Chart3D:
					{
						sb.Append("p3");
						break;
					}
			}










			// data
			if (_data == null)
			{
				throw new InvalidOperationException("Cannot generate chart with no data.");
			}

			sb.Append("&chd=t:");

			foreach (var d in _data)
			{

				sb.Append(d);
				sb.Append(',');
			}

			// remove training seperator
			sb.Length--;



			// labels
			if (_labels != null)
			{
				sb.Append("&chl=");

				foreach (var l in _labels)
				{
					sb.Append(HttpUtility.UrlEncode(l));
					sb.Append('|');
				}

				// remove training seperator
				sb.Length--;
			}





			// legends
			if (_legends != null)
			{
				sb.Append("&chdl=");

				foreach (var l in _legends)
				{
					sb.Append(l);
					sb.Append('|');
				}

				// remove training seperator
				sb.Length--;
			}


			// colours
			if (_colours != null)
			{
				sb.Append("&chco=");

				//int i = 0;
				foreach (var c in _colours)
				{
					sb.Append(c);
					sb.Append('|');

				}

				// remove training seperator
				sb.Length--;
			}




			return sb.ToString();

		}

		public GooglePieChart Legend(IEnumerable<string> legends)
		{
			_legends = legends;

			return this;
		}


		public GooglePieChart Legend(IEnumerable<string> legends, int widthMargin, int heightMargin)
		{
			_legends = legends;


			return base.LegendMargin(widthMargin, heightMargin);
		}

		public GooglePieChart Labels(IEnumerable<string> labels)
		{
			_labels = labels;

			return this;
		}


		public GooglePieChart Colours(IEnumerable<string> colours)
		{
			_colours = colours;

			return this;
		}

		public GooglePieChart DataAsPercentages(IEnumerable<double> data)
		{
			_data = data;

			return this;
		}

		public GooglePieChart DataRaw(IEnumerable<double> data)
		{
			return DataAsPercentages(data.ToPercentages());
		}





		public GooglePieChart Type(GoogleChartDimension type)
		{
			_type = type;

			return this;
		}



	}
}
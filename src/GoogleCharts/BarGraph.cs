/*
 * 
 * created: 30 Aug 2010 (DMG)
 * 
 * */

namespace McGiv.GoogleCharts
{
	// bar width type

	public enum BarChartAlignment
	{
		Horizontal,
		Vertical
	}

	public enum BarChartType
	{
		Stacked,
		Grouped
	}

	public class GoogleBarChart : MultiSeriesBase<GoogleBarChart>
	{
		private int _barSpacing = 4;
		private int _groupSpacing = 8;
		private BarChartAlignment _alignment = BarChartAlignment.Vertical;
		private BarChartType _type = BarChartType.Grouped;

		public GoogleBarChart BarSpacing(int spacing)
		{
			_barSpacing = spacing;

			return this;
		}

		public GoogleBarChart GroupSpacing(int spacing)
		{
			_groupSpacing = spacing;

			return this;
		}

		public GoogleBarChart Alignment(BarChartAlignment alignment)
		{
			_alignment = alignment;

			return this;
		}


		public GoogleBarChart Type(BarChartType type)
		{
			_type = type;

			return this;
		}



		public new string ToString()
		{
			var sb = GetBuilder();

			// type
			sb.Append("&cht=b");


			if(_alignment == BarChartAlignment.Horizontal)
			{
				sb.Append('h');
			}
			else
			{
				sb.Append('v');
			}


			if (_type == BarChartType.Grouped)
			{
				sb.Append('g');
			}
			else
			{
				sb.Append('s');
			}



			//chbh=  
			//<bar_width_or_scale>,<space_between_bars>,<space_between_groups>



			// chbh - width
			sb.Append("&chbh=");
			sb.Append('a'); // automatic
			sb.Append(',');
			sb.Append(_barSpacing);
			sb.Append(',');
			sb.Append(_groupSpacing);


			return sb.ToString();

		}
	}
}

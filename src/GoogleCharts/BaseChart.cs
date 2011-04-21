using System.Text;
using System.Web;


namespace McGiv.GoogleCharts
{
	public enum Position
	{
		Left,
		Right,
		Top,
		Bottom
	}

	public class Legend
	{
		public Position Position { get; set; }
		public int? Width { get; set; }
		public int Height { get; set; }
	}


	public class BaseGoogleChart<T>
		where T : BaseGoogleChart<T>
	{
		// title
		string _title;
		int _titleSize;
		string _titleColour;
		int _width = 100;
		int _height = 100;

		// margins
		private int _legendWidthmargin, _legendHeightMargin;
		private int _lefMargin, _rightmargin, _topmargin, _bottomMargin;

		public T Title(string title)
		{
			_title = title;


			return (T)this;
		}

		public T Title(string title, int size, string colour)
		{
			_title = title;
			_titleSize = size;
			_titleColour = colour;

			return (T)this;
		}



		public T Margin(int left, int right, int top, int bottom)
		{
			_lefMargin = left;
			_rightmargin = right;
			_topmargin = top;
			_bottomMargin = bottom;

			return (T)this;
		}


		public T LegendMargin(int width, int height)
		{
			_legendWidthmargin = width;
			_legendHeightMargin = height;

			return (T)this;
		}

		public T Size(int width, int height)
		{
			_width = width;
			_height = height;

			return (T)this;
		}

		public virtual StringBuilder GetBuilder()
		{
			var sb = new StringBuilder("http://chart.apis.google.com/chart?");


			// margins
			sb.Append("chma=");
			sb.Append(_lefMargin);
			sb.Append(',');
			sb.Append(_rightmargin);
			sb.Append(',');
			sb.Append(_topmargin);
			sb.Append(',');
			sb.Append(_bottomMargin);
			sb.Append('|');
			sb.Append(_legendWidthmargin);
			sb.Append(',');
			sb.Append(_legendHeightMargin);


			// title
			if (!string.IsNullOrEmpty(_title))
			{
				sb.Append("&chtt=");
				sb.Append(HttpUtility.UrlEncode(_title));


				if (!string.IsNullOrEmpty(_titleColour))
				{
					sb.Append("&chts=");
					sb.Append(_titleColour);
				}

				if (_titleSize > 0)
				{
					sb.Append(',');
					sb.Append(_titleSize);
				}

			}


			// dimensions
			sb.Append("&chs=");
			sb.Append(_width);
			sb.Append('x');
			sb.Append(_height);



			return sb;


		}
	}

}
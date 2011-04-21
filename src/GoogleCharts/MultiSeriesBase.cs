using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace McGiv.GoogleCharts
{
	public class MultiSeriesBase<T> : BaseGoogleChart<T>
		where T : MultiSeriesBase<T>
	{
		private readonly List<Axis> _axes = new List<Axis>();
		private readonly List<Series> _series = new List<Series>();

		#region Add Axis

		public T AddAxis(Axis axis)
		{
			_axes.Add(axis);

			return (T) this;
		}

		public T AddAxis(Position position, double start, double end, int? tickMarkLength)
		{
			return AddAxis(position, start, end, tickMarkLength, null);
		}

		public T AddAxis(Position position, double start, double end, int? tickMarkLength, IEnumerable<AxisLabel> labels)
		{
			_axes.Add(new Axis
			          	{
			          		Position = position,
			          		Start = start,
			          		End = end,
			          		TickMarkLength = tickMarkLength,
			          		Labels = labels == null ? null : labels.ToList()
			          	});

			return (T) this;
		}

		#endregion Add Axis

		#region AddSeries

		public T AddSeries(Series series)
		{
			_series.Add(series);

			return (T) this;
		}


		public T AddSeries(IEnumerable<double> data, string colour)
		{
			return AddSeries(
				new Series
					{
						Data = data,
						ColourHex = colour
					}
				);
		}

		public T AddSeries(IEnumerable<double> data, string colour, string legend)
		{
			return AddSeries(
				new Series
					{
						Data = data,
						ColourHex = colour,
						Legend = legend
					}
				);
		}

		#endregion AddSeries


		public override StringBuilder  GetBuilder()
		{
			var sb = base.GetBuilder();

			// series data
			sb.Append("&chd=t:");
			foreach (var s in _series)
			{
				foreach (var d in s.Data)
				{
					sb.Append(d);
					sb.Append(',');
				}

				sb.Length--;
				sb.Append('|');
			}
			sb.Length--;


			// series colours
			sb.Append("&chco=");
			foreach (var s in _series)
			{
				sb.Append(s.ColourHex);
				sb.Append(',');
			}
			sb.Length--;



			// series scale
			sb.Append("&chds=");
			foreach (var s in _series)
			{
				sb.Append(s.Min ?? 0);
				sb.Append(',');
				sb.Append(s.Max ?? s.Data.Max());
				sb.Append(',');
			}
			sb.Length--;


			// series legend
			sb.Append("&chdl=");
			foreach (var s in _series)
			{
				sb.Append(HttpUtility.UrlEncode(s.Legend));
				sb.Append('|');
			}
			sb.Length--;


			// axes
			if (_axes.Count > 0)
			{
				// positions
				sb.Append("&chxt=");
				foreach (var a in _axes)
				{
					switch (a.Position)
					{
						case Position.Left:
							{
								sb.Append('y');
								break;
							}
						case Position.Right:
							{
								sb.Append('r');
								break;
							}
						case Position.Top:
							{
								sb.Append('t');
								break;
							}
						case Position.Bottom:
							{
								sb.Append('x');
								break;
							}


					}
					sb.Append(',');
				}
				sb.Length--;


				// ranges
				if (_axes.Any(a => (a.Start != 0 && a.Start != null) || (a.End != 100 && a.End != null)))
				{
					sb.Append("&chxr=");
					int i = 0;
					foreach (var a in _axes)
					{
						if ((a.Start == 0 || a.Start == null) && (a.End == 100 || a.End == null))
						{
							i++;
							// ignore
							continue;
						}
						sb.Append(i);
						sb.Append(',');
						sb.Append(a.Start);
						sb.Append(',');
						sb.Append(a.End);
						sb.Append('|');
						i++;
					}

					sb.Length--;

				}

				// tickmarks 
				// 0,676767,11.5,0,lt,676767
				// chxs= <axis_index><optional_format_string>,<label_color>,<font_size>,<alignment>,<axis_or_tick>,<tick_color>
				if (_axes.Any(a => a.TickMarkLength != null))
				{
					sb.Append("&chxs=");
					int i = 0;
					foreach (var a in _axes)
					{
						if (a.TickMarkLength == null)
						{
							i++;
							continue;
						}

						sb.Append(i);
						sb.Append(',');
						sb.Append("676767"); // label_color
						sb.Append(',');
						sb.Append("11.5"); // font_size
						sb.Append(',');
						sb.Append('0'); // alignment
						sb.Append(',');
						sb.Append("lt"); // axis_or_tick
						sb.Append(',');
						sb.Append("676767"); // tick_color
						sb.Append('|');

						i++;
					}

					sb.Length--;
				}


				// label text
				if (_axes != null && _axes.Any(a => a.Labels != null && a.Labels.Count > 0))
				{




					// labels
					sb.Append("&chxl=");
					int i = 0;
					foreach (var a in _axes)
					{
						if (a.Labels != null)
						{
							sb.Append(i);
							sb.Append(':');
							sb.Append('|');
							foreach (var l in a.Labels)
							{

								sb.Append(HttpUtility.UrlEncode(l.Text));
								sb.Append('|');
							}
						}

						i++;
					}

					sb.Length--;



					// positions
					if (_axes.Any(a => a.Labels != null && a.Labels.Any(l => l.Position != null)))
					{
						sb.Append("&chxp=");
						i = 0;
						foreach (var a in _axes)
						{
							if (a.Labels != null)
							{
								sb.Append(i);
								sb.Append(',');
								foreach (var l in a.Labels)
								{
									sb.Append(l.Position);
									sb.Append(',');
								}
								sb.Length--;
								sb.Append('|');
							}

							i++;
						}

						sb.Length--;
					}

				}


			}


			return sb;
		}
	}
}
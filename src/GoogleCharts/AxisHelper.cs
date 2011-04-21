/*
 * created: 30 Aug 201 (DMG)
 * generates axis based on date range
 * 
 * */
using System;
using System.Collections.Generic;
using System.Linq;


namespace McGiv.GoogleCharts
{
	public static class AxisHelper
	{
		public static Axis GetDateAxis(Position position, DateTime from, DateTime to)
		{
			return new Axis
			{
				Position = position,
				Start = 0,
				End = (to.Date - from.Date).Days + 1,
				TickMarkLength = 5,
				Labels = GetDateAxisLabels(from, to).ToList()
			};
		}

		public static IEnumerable<AxisLabel> GetDateAxisLabels(DateTime from, DateTime to)
		{
			// todo validate from less then to
			int count = 0;
			DateTime current = from.Date;
			DateTime end = to.Date;
			if (current.Day == 1)
			{
				yield return new AxisLabel { Text = current.ToString("MMM"), Position = 0 };
				count += DateTime.DaysInMonth(current.Year, current.Month);
				current = current.AddMonths(1);
			}
			else
			{
				count += DateTime.DaysInMonth(current.Year, current.Month) - current.Day;
				current = current.AddDays(-current.Day).AddMonths(1);
			}

			while (true)
			{
				if (current < end)
				{
					yield return new AxisLabel { Text = current.ToString("MMM"), Position = count };
					count += DateTime.DaysInMonth(current.Year, current.Month);
					current = current.AddMonths(1);

				}
				else
				{
					break;
				}

			}


		}
	}
}

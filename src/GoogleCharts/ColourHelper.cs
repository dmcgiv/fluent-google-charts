using System.Collections.Generic;


namespace McGiv.GoogleCharts
{

	public static class ColourHelper
	{

		/// <summary>
		/// Returns a list of colours.
		/// </summary>
		/// <returns></returns>
		public static IEnumerable<string> GetColours()
		{
			// todo auto generate colours

			//FF3366 pink
			//686538 dark green
			// 686538 blue
			// C89C00 mustard
			// EE3000 reg
			// 0195EF blue
			// 1AD001 green
			// EBB604 mustard two


			yield return "8DD3C7";
			yield return "FFFFB3";
			yield return "BEBADA";
			yield return "FB8072";
			yield return "80B1D3";
			yield return "FDB462";
			yield return "B3DE69";
			yield return "FCCDE5";
			yield return "D9D9D9";
			yield return "BC80BD";
			yield return "CCEBC5";
			yield return "FFED6F";


		}
	}
}

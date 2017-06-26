using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ImageTool
{
	static class LinqExtensions
	{
		/// <summary>
		/// Sorts an IEnumerable using a natural sort.
		/// </summary>
		/// <param name="selector">Selects the key to sort by.</param>
		public static IEnumerable<T> OrderByAlphaNumeric<T>(this IEnumerable<T> source, Func<T, string> selector)
		{
			int max = source
				.SelectMany(i => Regex.Matches(selector(i), @"\d+").Cast<Match>().Select(m => (int?)m.Value.Length))
				.Max() ?? 0;

			return source.OrderBy(i => Regex.Replace(selector(i), @"\d+", m => m.Value.PadLeft(max, '0')));
		}
	}
}

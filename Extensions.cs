using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LinqFaroShuffle
{
    public static class Extensions
    {
		public static IEnumerable<T> InterleaveSequenceWith<T>(this IEnumerable<T> first, IEnumerable<T> second)
		{
			// your emplementation will go here soon enough

			var firstIter = first.GetEnumerator();
			var secondIter = second.GetEnumerator();

			while (firstIter.MoveNext() && secondIter.MoveNext())
			{
				yield return firstIter.Current;
				yield return secondIter.Current;
			}
		}

		public static bool SequenceEquals<T>(this IEnumerable<T> first, IEnumerable<T> second)
		{
			var firstIter = first.GetEnumerator();
			var secondIter = second.GetEnumerator();

			while (firstIter.MoveNext() && secondIter.MoveNext())
			{
				if (!firstIter.Current.Equals(secondIter.Current))
				{
					return false;
				}
			}
			return true;
		}

		public static IEnumerable<T> LogQuery<T> (this IEnumerable<T> sequence, string tag)
        {
			// File.AppendText creates a new file if the file doesn't exits.

			using(var writer = File.AppendText("debug.log"))
            {
				writer.WriteLine($"Executing Query {tag}");
            }

			return sequence;
        }
	}
}

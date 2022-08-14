using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqFaroShuffle
{
    
	class Program
    {
		static void Main()
		{
			// create Deck
			//var startingDeck = from s in Suits()
			//				   from r in Ranks()
			//				   select new { Suit = s, Rank = r };

			var startingDeck = Suits().LogQuery("Suit Generation").SelectMany(suit => Ranks().LogQuery("Value Generation").Select(rank => new { Suit = suit, Rank = rank })).LogQuery("Starting Deck").ToArray();


			// display each card taht we've generated and placed in startingDeck
			//foreach(var card in startingDeck){
			//	(card).Dump();
			//}

			// 52 cards in a deck, so 52 / 2 = 26

			//var top = startingDeck.Take(26);
			//var bottom = startingDeck.Skip(26);
			//var shuffle = top.InterleaveSequenceWith(bottom);
			//
			//foreach( var c in shuffle)
			//{
			//	(c).Dump();
			//}


			//var times = 0;
			//// we ca nre-use the shuffle variable from earlier, or you can make a new one
			//var shuffle = startingDeck;
			//
			//do
			//{
			//	shuffle = shuffle.Take(26).InterleaveSequenceWith(shuffle.Skip(26));
			//	
			//	foreach( var card in shuffle)
			//	{
			//		(card).Dump();
			//	}
			//	
			//	("============").Dump();
			//	times++;
			//} while(!startingDeck.SequenceEquals(shuffle));
			//
			//(times).Dump();

			var times = 0;
			// we ca nre-use the shuffle variable from earlier, or you can make a new one
			var shuffle = startingDeck;

			do
			{
				shuffle = shuffle.Skip(26).LogQuery("Bottom Half").InterleaveSequenceWith(shuffle.Take(26).LogQuery("Top Half"))
					.LogQuery("Shuffle").ToArray();

				foreach (var card in shuffle)
				{
					Console.WriteLine(card);
				}

				Console.WriteLine("-----------Time--------- {0}",times);
				times++;
			} while (!startingDeck.SequenceEquals(shuffle));

			Console.WriteLine(times);
		}

		static IEnumerable<string> Suits()
		{
			yield return "clubs";
			yield return "diamonds";
			yield return "hearts";
			yield return "spades";
		}

		static IEnumerable<string> Ranks()
		{
			yield return "two";
			yield return "three";
			yield return "four";
			yield return "five";
			yield return "six";
			yield return "seven";
			yield return "eight";
			yield return "nine";
			yield return "ten";
			yield return "jack";
			yield return "queen";
			yield return "king";
			yield return "ace";
		}
	}

	
}

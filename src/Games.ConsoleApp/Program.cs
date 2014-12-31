using System;
using System.Collections.Generic;
using System.Linq;
using Games.Pinochle;

namespace Games.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var players = new List<Player>
			{
				new Player("Lindsey", PlayerKind.Human),
				new Player("Mike", PlayerKind.Computer),
				new Player("A", PlayerKind.Computer),
				new Player("B", PlayerKind.Computer)
			};

			var pinochle = new PinochleGame(players);

			foreach (Player player in players)
				PrintPlayer(player);

			Console.ReadLine();
		}

		private static void PrintPlayer(Player player)
		{
			Console.WriteLine(player.Name);
			var clubs = string.Join(" ", player.Hand.Where(x => x.Suit == Suit.Club).Select(GetValue));
			var hearts = string.Join(" ", player.Hand.Where(x => x.Suit == Suit.Heart).Select(GetValue));
			var spades = string.Join(" ", player.Hand.Where(x => x.Suit == Suit.Spade).Select(GetValue));
			var diamonds = string.Join(" ", player.Hand.Where(x => x.Suit == Suit.Diamond).Select(GetValue));

			Console.WriteLine(" clubs:    " + MeldUtility.CountMeld(Suit.Club, player.Hand) + "   " + clubs);
			Console.WriteLine(" hearts:   " + MeldUtility.CountMeld(Suit.Heart, player.Hand) + "   " + hearts);
			Console.WriteLine(" spades:   " + MeldUtility.CountMeld(Suit.Spade, player.Hand) + "   " + spades);
			Console.WriteLine(" diamonds: " + MeldUtility.CountMeld(Suit.Diamond, player.Hand) + "   " + diamonds);
			Console.WriteLine();
		}

		private static string GetValue(Card card)
		{
			string value = ((int) card.FaceValue).ToString();
			if (card.FaceValue == FaceValue.Jack)
				value = "J";
			else if (card.FaceValue == FaceValue.Queen)
				value = "Q";
			else if (card.FaceValue == FaceValue.King)
				value = "K";
			else if (card.FaceValue == FaceValue.Ace)
				value = "A";

			if (card.Suit == Suit.Club)
				value += '\u2663';
			else if (card.Suit == Suit.Heart)
				value += '\u2665';
			else if (card.Suit == Suit.Spade)
				value += '\u2660';
			else if (card.Suit == Suit.Diamond)
				value += '\u2666';

			return value;
		}
	}
}

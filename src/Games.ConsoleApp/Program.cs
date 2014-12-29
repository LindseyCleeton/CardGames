
using System;
using System.Collections.Generic;
using System.Linq;

namespace Games.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var players = new List<Player>
			{
				new Player("Lindsey"),
				new Player("Mike   "),
				new Player("A      "),
				new Player("B      ")
			};

			var pinochle = new Pinochle(players);

			foreach (Player player in players)
				PrintPlayer(player);

		}

		private static void PrintPlayer(Player player)
		{
			Console.WriteLine(player.Name + " " + string.Join(" ", player.Hand.Select(GetValue)));
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

			
			if (card.Suite == Suite.Club)
				value += '\u2663';
			else if (card.Suite == Suite.Heart)
				value += '\u2665';
			else if (card.Suite == Suite.Spade)
				value += '\u2660';
			else if (card.Suite == Suite.Diamond)
				value += '\u2666';

			return value;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Games
{
	public sealed class Pinochle : Game
	{
		public Pinochle(ICollection<Player> players)
		{
			m_players = players;
			DealDeck();
		}

		public ICollection<Player> Players
		{
			get { return m_players; }
		}

		private static Deck CreateDeck()
		{
			List<Card> cards = new List<Card>();
			foreach (Suite suite in Enum.GetValues(typeof(Suite)))
			{
				for (uint value = 9; value < 15; value++)
				{
					// 10s beat kings
					cards.Add(new Card(suite, (FaceValue) value, value != 10 ? value : 13.5));
					cards.Add(new Card(suite, (FaceValue) value, value != 10 ? value : 13.5));
				}
			}

			return new Deck(cards);
		}

		private void DealDeck()
		{
			Deck deck = CreateDeck();
			deck.Shuffle();

			if (m_players.Count == 4)
			{
				foreach (Player player in m_players)
					player.SetHand(SortHand(deck.GetCards(12)));
			}
			else if (m_players.Count == 3)
			{
				m_kitty = deck.GetCards(3);
				foreach (Player player in m_players)
					player.SetHand(SortHand(deck.GetCards(15)));
			}
		}

		private ICollection<Card> SortHand(IEnumerable<Card> hand)
		{
			return hand
				.GroupBy(card => card.Suite)
				.OrderBy(group => group.Key)
				.Select(group => group.OrderBy(card => card.Value))
				.SelectMany(x => x)
				.ToList();
		}

		readonly ICollection<Player> m_players;
		ICollection<Card> m_kitty;
	}
}

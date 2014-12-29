using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Games
{
	public sealed class Deck
	{
		public Deck(IEnumerable<Card> cards)
		{
			m_cards = cards.ToList();
			m_random = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId));
		}

		public ICollection<Card> Cards
		{
			get { return m_cards; }
		}

		public void Shuffle()
		{
			for (int n = m_cards.Count - 1; n != 0; n--)
			{
				int k = m_random.Next(n + 1);
				Card value = m_cards[k];
				m_cards[k] = m_cards[n];
				m_cards[n] = value;
			}
		}

		public Card GetCard()
		{
			if (IsEmpty())
				return null;

			Card card = m_cards.First();
			m_cards.Remove(card);
			return card;
		}

		public ICollection<Card> GetCards(uint count)
		{
			List<Card> cards = new List<Card>();
			for (int x = 0; x < count; x++)
				cards.Add(GetCard());

			return cards;
		}

		public bool IsEmpty()
		{
			return m_cards.Count == 0;
		}

		readonly List<Card> m_cards;
		readonly Random m_random;
	}
}

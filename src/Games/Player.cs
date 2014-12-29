using System.Collections.Generic;

namespace Games
{
	public sealed class Player
	{
		public Player(string name)
		{
			m_name = name;
		}

		public string Name
		{
			get { return m_name; }
		}

		public ICollection<Card> Hand
		{
			get { return m_hand; }
		}

		public void SetHand(ICollection<Card> hand)
		{
			m_hand = hand;
		}

		readonly string m_name;
		ICollection<Card> m_hand;
	}
}

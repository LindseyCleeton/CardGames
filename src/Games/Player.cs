using System.Collections.Generic;

namespace Games
{
	public sealed class Player
	{
		public Player(string name, PlayerKind kind)
		{
			m_name = name;
			m_kind = kind;
		}

		public string Name
		{
			get { return m_name; }
		}

		public ICollection<Card> Hand
		{
			get { return m_hand; }
		}

		public PlayerKind Kind
		{
			get { return m_kind; }
		}

		public void SetHand(ICollection<Card> hand)
		{
			m_hand = hand;
		}

		readonly string m_name;
		readonly PlayerKind m_kind;
		ICollection<Card> m_hand;
	}
}


namespace Games
{
	public sealed class Card
	{
		public Card(Suit suit, FaceValue faceValue)
			: this(suit, faceValue, (int) faceValue)
		{
		}

		public Card(Suit suit, FaceValue faceValue, double value)
		{
			m_suit = suit;
			m_faceValue = faceValue;
			m_value = value;
		}

		public Suit Suit { get { return m_suit; } }
		public FaceValue FaceValue { get { return m_faceValue; } }
		public double Value { get { return m_value; } }

		readonly Suit m_suit;
		readonly FaceValue m_faceValue;
		readonly double m_value;
	}
}


namespace Games
{
	public sealed class Card
	{
		public Card(Suite suite, FaceValue faceValue, double value)
		{
			m_suite = suite;
			m_faceValue = faceValue;
			m_value = value;
		}

		public Suite Suite { get { return m_suite; } }
		public FaceValue FaceValue { get { return m_faceValue; } }
		public double Value { get { return m_value; } }

		readonly Suite m_suite;
		readonly FaceValue m_faceValue;
		readonly double m_value;
	}
}

using System.Collections.Generic;
using Games.Pinochle;
using NUnit.Framework;

namespace Games.UnitTests
{
	[TestFixture]
	public sealed class MeldTests
	{
		[Test]
		public void Test()
		{
			List<Card> hand = new List<Card>
			{
				new Card(Suit.Club, FaceValue.Ace),
				new Card(Suit.Club, FaceValue.Ten),
				new Card(Suit.Club, FaceValue.King),
				new Card(Suit.Club, FaceValue.Queen),
				new Card(Suit.Club, FaceValue.Jack),

				new Card(Suit.Heart, FaceValue.Jack),
				new Card(Suit.Heart, FaceValue.Ace),
				new Card(Suit.Heart, FaceValue.Ace),

				
				new Card(Suit.Diamond, FaceValue.Nine),
				new Card(Suit.Diamond, FaceValue.King),
				new Card(Suit.Diamond, FaceValue.Queen),
				new Card(Suit.Diamond, FaceValue.King),
			};

			Assert.AreEqual(7, MeldUtility.CountMeld(Suit.Diamond, hand));
		}
	}
}

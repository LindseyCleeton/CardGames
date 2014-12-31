using System.Collections.Generic;
using System.Linq;

namespace Games.Pinochle
{
	public static class MeldUtility
	{
		public static int CountMeld(Suit trump, ICollection<Card> hand)
		{
			int meld = 0;

			// sets
			meld += GetSetValue(FaceValue.Ace, singleValue: 10, doubleValue: 100, hand: hand);
			meld += GetSetValue(FaceValue.King, singleValue: 8, doubleValue: 80, hand: hand);
			meld += GetSetValue(FaceValue.Queen, singleValue: 6, doubleValue: 60, hand: hand);
			meld += GetSetValue(FaceValue.Jack, singleValue: 4, doubleValue: 40, hand: hand);

			// pinochle
			meld += GetPinochleValue(singleValue: 4, doubleValue: 30, hand: hand);

			// non-trump marriages
			List<Card> nonTrumpCards = hand.Where(x => x.Suit != trump).ToList();
			meld += GetMarriageValues(singleValue: 2, doubleValue: 4, nonTrumpCards: nonTrumpCards);

			// trump family
			List<Card> trumpCards = hand.Where(x => x.Suit == trump).ToList();
			meld += GetFamilyValues(singleValue: 15, doubleValue: 150, extraKingOrQueenValue: 2, marriageValue: 4, doubleMarriageValue: 8, trumpCards: trumpCards);

			return meld;
		}

		private static int GetSetValue(FaceValue faceValue, int singleValue, int doubleValue, IEnumerable<Card> hand)
		{
			List<Card> cards = hand.Where(x => x.FaceValue == faceValue).ToList();
			if (cards.Count == 8)
				return doubleValue;

			if (cards.Count >= 4 && new HashSet<Suit>(cards.Select(x => x.Suit)).Count == 4)
				return singleValue;

			return 0;
		}

		private static int GetPinochleValue(int singleValue, int doubleValue, ICollection<Card> hand)
		{
			int queensOfSpades = hand.Count(x => x.FaceValue == FaceValue.Queen && x.Suit == Suit.Spade);
			int jacksOfDiamonds = hand.Count(x => x.FaceValue == FaceValue.Jack && x.Suit == Suit.Diamond);

			if (queensOfSpades == 2 && jacksOfDiamonds == 2)
				return doubleValue;

			if (queensOfSpades != 0 && jacksOfDiamonds != 0)
				return singleValue;

			return 0;
		}

		private static int GetMarriageValues(int singleValue, int doubleValue, IEnumerable<Card> nonTrumpCards)
		{
			int value = 0;
			foreach (var group in nonTrumpCards.GroupBy(x => x.Suit))
			{
				int kings = group.Count(x => x.FaceValue == FaceValue.King);
				int queens = group.Count(x => x.FaceValue == FaceValue.Queen);
				if (kings == 2 && queens == 2)
					value += doubleValue;
				else if (kings != 0 && queens != 0)
					value += singleValue;
			}

			return value;
		}

		private static int GetFamilyValues(int singleValue, int doubleValue, int extraKingOrQueenValue, int marriageValue, int doubleMarriageValue, ICollection<Card> trumpCards)
		{
			int aces = trumpCards.Count(x => x.FaceValue == FaceValue.Ace);
			int tens = trumpCards.Count(x => x.FaceValue == FaceValue.Ten);
			int kings = trumpCards.Count(x => x.FaceValue == FaceValue.King);
			int queens = trumpCards.Count(x => x.FaceValue == FaceValue.Queen);
			int jacks = trumpCards.Count(x => x.FaceValue == FaceValue.Jack);
			int nines = trumpCards.Count(x => x.FaceValue == FaceValue.Nine);

			bool hasDoubleFamily = aces == 2 && tens == 2 && kings == 2 && queens == 2 && jacks == 2;
			bool hasSingleFamily = !hasDoubleFamily && aces != 0 && tens != 0 && kings != 0 && queens != 0 && jacks != 0;
			bool hasExtraKing = hasSingleFamily && kings == 2;
			bool hasExtraQueen = hasSingleFamily && queens == 2;
			bool hasDoubleMarriage = !hasSingleFamily && !hasDoubleFamily && kings == 2 && queens == 2;
			bool hasSingleMarriage = !hasSingleFamily && !hasDoubleFamily && !hasDoubleMarriage && kings != 0 && queens != 0;

			int value = 0;
			if (hasDoubleFamily)
			{
				value = doubleValue;
			}
			else if (hasSingleFamily)
			{
				value = singleValue;
				if (hasExtraKing)
					value += extraKingOrQueenValue;
				if (hasExtraQueen)
					value += extraKingOrQueenValue;
			}
			else
			{
				if (hasDoubleMarriage)
					value = doubleMarriageValue;
				else if (hasSingleMarriage)
					value = marriageValue;
			}

			value += nines;

			return value;
		}
	}
}

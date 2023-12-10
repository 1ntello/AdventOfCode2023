using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AOC2023.Challenges
{

    public class Hand
    {
        public Card[] Cards { get; set; }
        public int Rank { get; set; }
        public int Bid { get; set; }
    }

    public class Card 
    {
        public Card(char card, int value)
        {
            CardKey = card;
            Value = value;
        }
        public char CardKey;
        public int Value;
    }

   
    // make enum with all types
    public enum Rank
    {
        FiveOfAKind = 1, 
        FourOfAKind = 2, 
        FullHouse = 3, 
        ThreeOfAKind = 4, 
        TwoPair = 5,
        OnePair = 6, 
        HighCard = 7
    }

    // make enum with cards

    public class Challenge7
    {
        public Card[] AllCards
        {
            get
            {
                Card[] fullHand = new Card[13]
                {
                    new Card('A', 13),
                    new Card('K', 12),
                    new Card('Q', 11),
                    new Card('J', 10),
                    new Card('T', 9),
                    new Card('9', 8),
                    new Card('8', 7),
                    new Card('7', 6),
                    new Card('6', 5),
                    new Card('5', 4),
                    new Card('4', 3),
                    new Card('3', 2),
                    new Card('2', 1),
                };
                return fullHand;
            }
        }
        public List<Hand> GetAllHandsRanked(string[] data)
        {
            List<Hand> Hands = new List<Hand>();
            // foreach card convert to enum 
            foreach (string dataLine in data)
            {
                // split into hand and bid
                var splitString = dataLine.Split(' ');
                var hand = splitString[0];
                var bid = splitString[1];

                Hand convertedHand = CardStringToHand(hand);
                Rank handRank = GetRankFromHand(convertedHand);
                convertedHand.Rank = (int)handRank;
                convertedHand.Bid = int.Parse(bid);

                var hasOtherHandWithSameRank = Hands.Any(x => x.Rank == convertedHand.Rank);
                if (hasOtherHandWithSameRank)
                {
                    var handWithSameRank = Hands.Single(x => x.Rank == convertedHand.Rank);
                    Hand biggestHand;
                    // figure out which is higer then reshuffle. 
                    biggestHand = WhichHandIsBigger(convertedHand, handWithSameRank);
                    biggestHand.Rank = biggestHand.Rank - 1;

                    Hands.Where(x => x.Rank <= biggestHand.Rank).ToList().ForEach(x => x.Rank = x.Rank - 1);
                    Hands.Where(x => x.Rank > biggestHand.Rank).ToList().ForEach(x => x.Rank = x.Rank + 1);
                }
                Hands.Add(convertedHand);
            }
            return Hands;
        }

        private Hand WhichHandIsBigger(Hand convertedHand, Hand handWithSameRank)
        {
            for (int i = 0; i < handWithSameRank.Cards.Count(); i++)
            {
                var card1 = convertedHand.Cards[i];
                var card2 = handWithSameRank.Cards[i];

                if (card1.Value != card2.Value) 
                {
                    var highest = int.Max(card1.Value, card2.Value);
                    if (highest == card1.Value)
                        return convertedHand;
                    else
                        return handWithSameRank;
                }
            }
            return default(Hand);
        }

        private Hand CardStringToHand(string cardString)
        {
            Hand hand = new Hand();
            hand.Cards = new Card[5];

            for (int i = 0; i <= cardString.Length - 1; i++)
            {
                hand.Cards[i] = GetCard(cardString[i]);
            }
            return hand;
        }
        // return hand with type 
        private Rank GetRankFromHand(Hand Hand)
        {
            // We check for all options 
            // lazy lazy options
            Dictionary<char, int> cardCounts = new Dictionary<char, int>();
            foreach (var card in Hand.Cards)
            {
                if (!cardCounts.ContainsKey(card.CardKey))
                    cardCounts.Add(card.CardKey, 1);
                else
                    cardCounts[card.CardKey]++;
            }
            var highestCountedCard = cardCounts.OrderBy(x => x.Value).First();
            var secondHighestCard = cardCounts.OrderBy(x => x.Value).ElementAt(1);
            if (highestCountedCard.Value == 5)
                return Rank.FiveOfAKind;
            else if (highestCountedCard.Value == 4)
                return Rank.FourOfAKind;
            else if (highestCountedCard.Value + secondHighestCard.Value == 5)
                return Rank.FullHouse; // see this works because it cant be 5 - 0 or 4 - 1 (hacks) 
            else if (highestCountedCard.Value == 3)
                return Rank.ThreeOfAKind;
            else if (highestCountedCard.Value == 2 && secondHighestCard.Value == 2)
                return Rank.TwoPair;
            else if (highestCountedCard.Value == 2)
                return Rank.OnePair;
            else
                return Rank.HighCard;

            return default(Rank);
        }
        // if type matches one in our collection, check the cards until one is better, and reshuffle
        private Card GetCard(char cardKey)
        {
            var card =  AllCards.Single(X => X.CardKey == cardKey);
            return card;
        }

        
    }
}

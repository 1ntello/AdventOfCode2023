using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2023.Challenges
{
    public class Challenge4
    {
        public int CalculateTotalPoints(string[] cards)
        {
            int totalPoints = 0;
            foreach (string card in cards)
            {
                totalPoints += CalculateScoreOfCard(card);
            }
            return totalPoints;
        }

        public int CalculateScoreOfCard(string card)
        {
            var winningNumberString = card.Split('|')[0].Split(':')[1];
            var ownedNumberString = card.Split('|')[1];


            var winningNumbers = winningNumberString.Split(' ').Where(x => x != "");
            var ownedNumbers = ownedNumberString.Split(' ').Where(x => x != "");

            int winningCards = 0;
            int points = 0;
            foreach (var number in winningNumbers)
            {
                if (ownedNumbers.Contains(number))
                {
                    winningCards++;
                    if (points == 0)
                        points = 1;
                    else
                        points = (points * 2);
                }
            }
            return points;
        }

        private struct ScratchCard
        {
            public int Card { get; set;  }
            public int Score { get; set; }
        }
        public int CalculateTotalScratchCards(string[] data)
        {
            Dictionary<int, int> CardWithAmount = new Dictionary<int, int>();

            for(int z = 1; z < data.Length + 1;z++)
                CardWithAmount.Add(z, 1);
            int cardCounter = 1;
            string currentCard = data[0];
            for(int c = 0; c < data.Length - 1; c++)
            {
                var winningNumbers = HowManyWinningNumbers(currentCard);
                var loopMax = CardWithAmount[cardCounter];
                for (int t = 0; t < loopMax; t++)
                {
                    int cardToUpdate = cardCounter + 1;
                    for (int j = 0; j < winningNumbers; j++)
                    {
                        CardWithAmount[cardToUpdate]++;
                        cardToUpdate++;
                    }
                }
                currentCard = data[c + 1];
                cardCounter++;
            }
           
            return CardWithAmount.Sum(x => x.Value);
        }

        private int HowManyWinningNumbers(string card)
        {
            var winningNumberString = card.Split('|')[0].Split(':')[1];
            var ownedNumberString = card.Split('|')[1];
            var winningNumbers = winningNumberString.Split(' ').Where(x => x != "");
            var ownedNumbers = ownedNumberString.Split(' ').Where(x => x != "");

            return ownedNumbers.Intersect(winningNumbers).Count();
        }
    }
}

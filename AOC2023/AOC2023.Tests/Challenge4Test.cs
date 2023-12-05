using AOC2023.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2023.Tests
{
    internal class Challenge4Test
    {

        [Test]
        [TestCase("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 8)]
        [TestCase("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2)]
        [TestCase("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", 2)]
        [TestCase("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", 1)]
        [TestCase("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", 0)]
        [TestCase("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", 0)]
        public void Challenge4_TestScoreOfCards(string card, int expectedScore)
        {
            Challenge4 challenge = new Challenge4();
            int points = challenge.CalculateScoreOfCard(card);
            Assert.That(points, Is.EqualTo(expectedScore));
        }

        [Test]
        public void Challenge4_Part2()
        {
            string[] cards = new string[6]
            {
               "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
               "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
               "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
               "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
               "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
               "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
            };

            Challenge4 challenge = new Challenge4();
            int total = challenge.CalculateTotalScratchCards(cards);
            Assert.That(total, Is.EqualTo(30));
        }
    }
}

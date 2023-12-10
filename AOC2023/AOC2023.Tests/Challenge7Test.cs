using AOC2023.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2023.Tests
{
    public class Challenge7Test
    {
        [Test]
        public void Challenge7_HandsAreCorrectlyRanked()
        {
            Challenge7 challenge = new Challenge7();
            string[] hands = new string[5]
            {
                "32T3K 765", 
                "T55J5 684",
                "KK677 28", 
                "KTJJT 220",
                "QQQJA 483"
            };
            List<Hand> result = challenge.GetAllHandsRanked(hands);
        }

        [Test]
        public void Challenge7_TotalBets()
        {
          
        }
    }
}

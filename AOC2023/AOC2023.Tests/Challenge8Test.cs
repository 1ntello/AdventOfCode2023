using AOC2023.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2023.Tests
{
    internal class Challenge8Test
    {
        [Test]
        public void Challenge8_StartTest()
        {
            string[] data = new string[9]
            {
                "RL",
                "",
                "AAA = (BBB, CCC)",
                "BBB = (DDD, EEE)",
                "CCC = (ZZZ, GGG)",
                "DDD = (DDD, DDD)",
                "EEE = (EEE, EEE)",
                "GGG = (GGG, GGG)",
                "ZZZ = (ZZZ, ZZZ)"
            };
            Challenge8 challenge = new Challenge8();
            var result = challenge.TraverseTheHauntedWasteLand(data.ToList());
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Challenge8_SixSteps()
        {
            string[] data = new string[5]
            {
                "LLR",
                "",
                "AAA = (BBB, BBB)",
                "BBB = (AAA, ZZZ)",
                "CCC = (ZZZ, ZZZ)",
            };
            Challenge8 challenge = new Challenge8();
            var result = challenge.TraverseTheHauntedWasteLand(data.ToList());
            Assert.That(result, Is.EqualTo(6));
        }
    }
}

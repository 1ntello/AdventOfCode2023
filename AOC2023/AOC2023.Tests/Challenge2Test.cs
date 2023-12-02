using AOC2023.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2023.Tests
{
    internal class Challenge2Test
    {
        [Test]
        [TestCase("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", true)]
        [TestCase("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", true)]
        [TestCase("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", false)]
        [TestCase("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", false)]
        [TestCase("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", true)]
        public void Challenge2_TestGameValidity(string testData, bool expectedResult) 
        {
            Challenge2 challenge = new Challenge2();
            int result = challenge.StartValidation(testData, 12, 13, 14);
            bool valid = result != -1;
            Assert.That(valid, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 48)]
        [TestCase("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 12)]
        [TestCase("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 1560)]
        [TestCase("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 630)]
        [TestCase("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 36)]
        public void Challenge2_TestPowerCorrect(string testData, int expectedResult)
        {
            Challenge2 challenge = new Challenge2();
            int result = challenge.GetLowestAllowedPower(testData);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

    }
}

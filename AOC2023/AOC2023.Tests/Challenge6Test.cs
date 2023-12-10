using AOC2023.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2023.Tests
{
    internal class Challenge6Test
    {
        [Test]
        public void Challenge6Test_GetAmountOfOptions()
        {
            string[] data = new string[2]
            {
                "Time:      7  15   30",
                "Distance:  9  40  200"
            };
            Challenge6 challenge = new Challenge6();
            int options = challenge.CalculateAmountOfOptions(data);
            Assert.That(options, Is.EqualTo(4));
        }


        [Test]
        public void Challenge6Test_Part2_BigRace()
        {
            string[] data = new string[2]
            {
                "Time:      7  15   30",
                "Distance:  9  40  200"
            };
            Challenge6 challenge = new Challenge6();
            int options = challenge.CalculateBigRace(data);
            Assert.That(options, Is.EqualTo(71503));
        }
    }
}

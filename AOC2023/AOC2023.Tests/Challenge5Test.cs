using AOC2023.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2023.Tests
{
    internal class Challenge5Test
    {
        [Test]
        public void Challenge5_TestLowestLocation()
        {
            Challenge5 challenge = new Challenge5();
            var lines = File.ReadAllLines("data/challenge5.txt");
            var result = challenge.CrazyChallenge(lines);
            Assert.That(result, Is.EqualTo(35));
        }

        [Test]
        public void Challenge5_TestWithSeeds()
        {
            Challenge5 challenge = new Challenge5();
            var lines = File.ReadAllLines("data/challenge5.txt");
            var result = challenge.CrazyChallenge_MoarSeeds(lines);
            Assert.That(result, Is.EqualTo(46));
        }
    }
}

using AOC2023.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2023.Tests
{
    internal class Challenge3Test
    {
        [Test]
        public void TestData()
        {
            string[] testdata = new string[10]
            {
                "467..114..",
                "...*......",
                "..35..633.",
                "......#...",
                "617*......",
                ".....+.58.",
                "..592.....",
                "......755.",
                "...$.*....",
                ".664.598..",
            };

            Challenge3 challenge = new Challenge3();
            int sum = challenge.GetSumOfInstructions(testdata);
            Assert.That(sum, Is.EqualTo(4361));

        }

        [Test]
        public void RedditTester()
        {
            string[] testdata = new string[11]
            {
                "12.......*..",
                "+.........34",
                ".......-12..",
                "..78........",
                "..*....60...",
                "78..........",
                ".......23...",
                "....90*12...",
                "2.2......12.",
                ".*.........*",
                "1.1.......56"
            };


            Challenge3 challenge = new Challenge3();
            int sum = challenge.GetSumOfInstructions(testdata);
            Assert.That(sum, Is.EqualTo(413));
        }
    }
}

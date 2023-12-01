using AOC2023.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2023.Tests
{
    internal class Challenge1Test
    {
        Challenge1 challenge1 = new Challenge1();


        [Test]
        [TestCase("1abc2", 12)]
        [TestCase("pqr3stu8vwx", 38)]
        [TestCase("a1b2c3d4e5f", 15)]
        [TestCase("treb7uchet", 77)]
        public void CalculateCalibrationValue(string s, int expected)
        {
            var result = challenge1.CalculateCalibrationValue(s);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CalculateTotalOfCalibrationValues()
        {
            string[] calibrationValues = new string[4] { "1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet" };
            var result = challenge1.CalculateSumOfCalibrationValues(calibrationValues);
            Assert.That(result, Is.EqualTo(12 + 38 + 15 + 77));
        }
    }
}

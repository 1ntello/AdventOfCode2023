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
        [TestCase("two1nine", 29)]
        [TestCase("eightwothree", 83)]
        [TestCase("abcone2threexyz", 13)]
        [TestCase("xtwone3four", 24)]
        [TestCase("4nineeightseven2", 42)]
        [TestCase("zoneight234", 14)]
        [TestCase("7pqrstsixteen", 76)]
        public void CalculateCalibrationValueWithLetters(string s, int expected)
        {
            var result = challenge1.CalculateCalibrationValueWithLettersAndNumbers(s);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CalculateTotalOfCalibrationValues()
        {
            string[] calibrationValues = new string[4] { "1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet" };
            var result = challenge1.CalculateSumOfCalibrationValues(calibrationValues);
            Assert.That(result, Is.EqualTo(12 + 38 + 15 + 77));
        }

        [Test]
        public void CalculateTotalOfCalibrationValuesWithLetters()
        {
            string[] calibrationValues = new string[7] { "two1nine", "eightwothree", "abcone2threexyz", "xtwone3four", "4nineeightseven2", "zoneight234", "7pqrstsixteen" };
            var result = challenge1.CalculateSumOfCalibrationValuesWithLetters(calibrationValues);
            Assert.That(result, Is.EqualTo(29 + 83 + 13 + 24 + 42 + 14 + 76));
        }
    }
}

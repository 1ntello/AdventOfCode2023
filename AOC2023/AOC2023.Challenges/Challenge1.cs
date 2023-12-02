using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace AOC2023.Challenges
{
    public class Challenge1
    {
        public int CalculateSumOfCalibrationValues(string[] data)
        {
            int result = 0;
            foreach (var item in data)
            {
                result += CalculateCalibrationValue(item);
            }
            return result;
        }

        public int CalculateSumOfCalibrationValuesWithLetters(string[] data)
        {
            int result = 0;
            int counter = 0;
            foreach (var item in data)
            {
                var calibratedValue =  CalculateCalibrationValueWithLettersAndNumbers(item);
                Console.WriteLine($"{item} becomes {calibratedValue} and we do {result} + {calibratedValue}");
                result += calibratedValue;
                counter++;
            }
            Console.WriteLine(counter);
            return result;
        }

        public int CalculateCalibrationValue(string calibrationLine)
        {
            var numbers = calibrationLine.Where(x => char.IsNumber(x));
            return int.Parse($"{numbers.First()}{numbers.Last()}");
        }

        public int CalculateCalibrationValueWithLettersAndNumbers(string calibrationLine)
        {
            var resultString = StringToNumberString(calibrationLine);
            var numbers = resultString.Where(char.IsNumber);
            if(numbers.Count() > 1) 
                return int.Parse($"{numbers.First()}{numbers.Last()}");
            else
                return int.Parse($"{numbers.First()}");
        }

        public string StringToNumberString(string inputstring)
        {
 
            Dictionary<int, string> indexes = new Dictionary<int, string>();
            Dictionary<string, int> numbers = new Dictionary<string, int>
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 }
            };

            foreach (var n in numbers)
            {
                // we thought too easy because eightwo is apparently eight and two 
                // so we have to save the indexes and the number and the indexes of normal numbers
                if (inputstring.Contains(n.Key))
                {
                    List<int> foundIndexes = new List<int>();
                    for (int i = inputstring.IndexOf(n.Key); i > -1; i = inputstring.IndexOf(n.Key, i + 1))
                    {
                        // for loop end when i=-1 ('a' not found)
                        foundIndexes.Add(i);
                    }
                    foreach (var index in foundIndexes) {
                        indexes.Add(index, n.Value.ToString());
                    }

                }
                if (inputstring.Contains(n.Value.ToString()))
                {
                    List<int> foundIndexes = new List<int>();
                    for (int i = inputstring.IndexOf(n.Value.ToString()); i > -1; i = inputstring.IndexOf(n.Value.ToString(), i + 1))
                    {
                        // for loop end when i=-1 ('a' not found)
                        foundIndexes.Add(i);
                    }
                    foreach (var index in foundIndexes)
                    {
                        indexes.Add(index, n.Value.ToString());
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (var index in indexes.OrderBy(x => x.Key).ToList())
            {
                sb.Append(index.Value);
            }
            Console.WriteLine($"{inputstring} becomes {sb.ToString()}");
            return sb.ToString();
        }
    }
}

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

        public int CalculateCalibrationValue(string calibrationLine)
        {
            var numbers = calibrationLine.Where(x => char.IsNumber(x));
            return int.Parse($"{numbers.First()}{numbers.Last()}");
        }
    }
}

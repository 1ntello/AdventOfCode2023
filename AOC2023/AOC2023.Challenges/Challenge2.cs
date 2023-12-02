using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2023.Challenges
{
    public class Challenge2
    {
        public int RunChallenge(string[] data)
        {
            int total = 0;
            foreach (var d in data)
            {
                var result = StartValidation(d, 12, 13, 14);
                if (result > 0)
                    total += result;
            }
            return total;
        }

        public int RunChallengePart2(string[] data)
        {
            int total = 0;
            foreach (var d in data)
            {
                var result = GetLowestAllowedPower(d);
                total += result;
            }
            return total;
        }
        public int StartValidation(string gameString, int amountOfRedAllowed, int amountOfGreenAllowed, int amountOfBlueAllowed)
        {
            Console.WriteLine($"Validating {gameString}");
            var result = -1;
            bool valid = true;
            var gameSplit = gameString.Split(':');
            var gameName = gameSplit[0].Split(' ')[1];

            var games = gameSplit[1].Split(';');
            foreach (var g in games)
            {
                var draws = g.Split(',');
                foreach (var d in draws)
                {
                    var amountSplit = d.Split(' ');
                    var amount = int.Parse(amountSplit[1]);
                    var type = amountSplit[2];
                    if ((type == "red" && amount > amountOfRedAllowed) || (type == "blue" && amount > amountOfBlueAllowed) || (type == "green" && amount > amountOfGreenAllowed))
                    {
                        Console.WriteLine($"This game is invalid because {type} with {amount} is not allowed");
                        valid = false;
                    }
                }
            }
            if (valid)
            {
                Console.WriteLine($"This game is valid, so we are returning {gameName}");
                result = int.Parse(gameName);
            }

            return result; 
        }

        public int GetLowestAllowedPower(string gameString)
        {
            Console.WriteLine($"Validating {gameString}");
            var gameSplit = gameString.Split(':');
            var gameName = gameSplit[0].Split(' ')[1];

            int highestRed = 0;
            int highestBlue = 0;
            int highestGreen = 0;

            var games = gameSplit[1].Split(';');
            foreach (var g in games)
            {
                var draws = g.Split(',');
                foreach (var d in draws)
                {
                    var amountSplit = d.Split(' ');
                    var amount = int.Parse(amountSplit[1]);
                    var type = amountSplit[2];
                    if ((type == "red" && amount > highestRed))
                        highestRed = amount;
                    if ((type == "blue" && amount > highestBlue))
                        highestBlue = amount;
                    if ((type == "green" && amount > highestGreen))
                        highestGreen = amount;
                   
                }
            }
           
            return highestRed * highestGreen * highestBlue;
        }
    }
}

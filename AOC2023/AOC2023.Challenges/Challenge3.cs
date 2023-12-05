using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2023.Challenges
{
    public class Challenge3
    {
        public int GetSumOfInstructions(string[] instructions)
        {
            return ReadGondolaInstructions(instructions).Sum();
        }
        public List<int> ReadGondolaInstructions(string[] instructions)
        {
            ConsoleColor color = ConsoleColor.White;
            Dictionary<Point, char> matrix = new Dictionary<Point, char>();
            List<int> partNumbers = new List<int>();
            int row = 0;
            foreach (var i in instructions)
            {
                int col = 0;
                foreach (var j in i)
                {
                    matrix.Add(new Point(row, col), j);
                    col++;
                }
                row++;
            }
            matrix.Add(new Point(matrix.Max(x => x.Key.X), matrix.Max(y => y.Key.Y + 1)), '.');

            Dictionary<Point, char> currentNumberToCheck = new Dictionary<Point, char>();
            char lastchar = ' ';
            int currentRow = 0;
            foreach (var m in matrix)
            {
                color = ConsoleColor.White;
                if (m.Key.X > currentRow && char.IsNumber(m.Value))
                {
                    currentRow++;
                    currentNumberToCheck = new Dictionary<Point, char>();
                }
                if (char.IsNumber(m.Value))
                    currentNumberToCheck.Add(m.Key, m.Value);
                if (!char.IsNumber(m.Value) && char.IsNumber(lastchar))
                {
                    // now we check if adjacent to symbol. 
                    foreach (var current in currentNumberToCheck)
                    {
                        int x = current.Key.X;
                        int y = current.Key.Y;
                        // check chars above and below and left and right so 
                        List<char> adjacentChars = new List<char>
                        {
                            //matrix.ContainsKey(new Point(x, y)) ? matrix[new Point(x, y)] : '.',
                            matrix.ContainsKey(new Point(x + 1, y)) ? matrix[new Point(x + 1, y)] : '.',
                            matrix.ContainsKey(new Point(x - 1, y)) ? matrix[new Point(x -1 , y)] : '.',
                            matrix.ContainsKey(new Point(x, y + 1)) ? matrix[new Point(x, y + 1)] : '.',
                            matrix.ContainsKey(new Point(x , y - 1)) ? matrix[new Point(x , y - 1)] : '.',
                            matrix.ContainsKey(new Point(x + 1, y + 1)) ? matrix[new Point(x + 1, y + 1)] : '.',
                            matrix.ContainsKey(new Point(x - 1, y - 1)) ? matrix[new Point(x - 1 , y - 1)] : '.',
                            matrix.ContainsKey(new Point(x + 1, y - 1)) ? matrix[new Point(x + 1, y - 1 )] : '.',
                            matrix.ContainsKey(new Point(x - 1, y + 1)) ? matrix[new Point(x - 1, y + 1 )] : '.',
                        };
                        if (adjacentChars.Any(isSpecialCharacter)) // blame it on fucking c#
                        {
                            color = ConsoleColor.Green;
                            StringBuilder s = new StringBuilder();
                            foreach (var c in currentNumberToCheck)
                            {
                                s.Append(c.Value);
                            }
                            //Console.WriteLine($"{s.ToString()} is adjacent to a { adjacentChars.Where(isSpecialCharacter).First()}");
                            partNumbers.Add(int.Parse(s.ToString()));
                            break;

                        }
                    }
                    currentNumberToCheck = new Dictionary<Point, char>();
                }
                Console.ForegroundColor = color;
                Console.WriteLine(m.Value);
                lastchar = m.Value;
            }
            return partNumbers;
        }

        private bool isSpecialCharacter(char c)
        {
            // fuck you c# apparently .isSymbol does not work on any of your fucking symbols 
            return !char.IsLetterOrDigit(c) && c != '.';
        }
    }

}


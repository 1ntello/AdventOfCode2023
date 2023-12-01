// See https://aka.ms/new-console-template for more information
using AOC2023.Challenges;

Console.WriteLine("Hello, World!");

Challenge1 challenge = new Challenge1();
var result = challenge.CalculateSumOfCalibrationValues(File.ReadAllLines("challenges/challenge1.txt"));
Console.WriteLine(result);
Console.ReadKey();
// See https://aka.ms/new-console-template for more information
using AOC2023.Challenges;

Console.WriteLine("Hello, World!");

Challenge1 challenge = new Challenge1();
var result = challenge.CalculateSumOfCalibrationValuesWithLetters(File.ReadAllLines("challenges/challenge1.txt"));
Console.WriteLine("final answer: " + result);
Console.ReadKey();

//Challenge2 challenge2 = new Challenge2();
//var result = challenge2.RunChallengePart2(File.ReadAllLines("challenges/challenge2.txt"));
//Console.WriteLine("final answer: " + result);
//Console.ReadKey();
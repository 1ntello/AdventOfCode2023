// See https://aka.ms/new-console-template for more information
using AOC2023.Challenges;

Console.WriteLine("ADVENT OF CODE - RUN: ");

Challenge8 challenge8 = new Challenge8();
var result = challenge8.TraverseTheHauntedWasteLand(File.ReadAllLines("challenges/challenge8.txt").ToList());
Console.WriteLine("final answer: " + result);
Console.ReadKey();
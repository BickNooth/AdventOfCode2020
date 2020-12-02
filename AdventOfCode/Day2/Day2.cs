using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day2
{
    public class Day2
    {
        public static void Run(string filePath)
        {
            var inputLines = ReadInputLinesFromFile(filePath);

            var correctPasswords = ValidatePasswords(inputLines);
            Console.WriteLine("Correct Passwords: " + correctPasswords);
        }

        private static int ValidatePasswords(IEnumerable<InputLine> inputLines)
        {
            var countOfValidPasswords = 0;
            foreach (var inputLine in inputLines)
            {
                var regex =
                    new Regex($"[{inputLine.RepeatingLetter}]");

                var matches = regex.Matches(inputLine.Password);

                var isValidPassword =
                    inputLine.MaxOccurrence >= matches.Count && matches.Count >= inputLine.MinOccurrence;

                Console.WriteLine($"{isValidPassword} for {inputLine.Password}");
                countOfValidPasswords += isValidPassword ? 1 : 0;
            }

            return countOfValidPasswords;
        }

        private static IEnumerable<InputLine> ReadInputLinesFromFile(string testInputFile)
        {
            var lineArray = File.ReadAllLines($"./Day2/{testInputFile}");

            var inputLines = new List<InputLine>();
            var regex = new Regex(@"(\d{1,3})-(\d{1,3}) (\w): (\w+)");

            foreach (var line in lineArray)
            {
                var matches = regex.Matches(line);

                inputLines.Add(new InputLine
                               {
                                   MinOccurrence = int.Parse(matches[0].Groups[1].Value),
                                   MaxOccurrence = int.Parse(matches[0].Groups[2].Value),
                                   RepeatingLetter = matches[0].Groups[3].Value,
                                   Password = matches[0].Groups[4].Value
                               });
            }

            return inputLines;
        }

        private class InputLine
        {
            public int MinOccurrence { get; set; }
            public int MaxOccurrence { get; set; }
            public string RepeatingLetter { get; set; }
            public string Password { get; set; }
        }
    }
}
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
                var passwordSplit = inputLine.Password.ToCharArray();

                var firstPosition = passwordSplit[inputLine.FirstPosition - 1].ToString();
                var secondPosition = passwordSplit[inputLine.SecondPosition - 1].ToString();

                bool isValidPassword;
                if (firstPosition == inputLine.RepeatingLetter && secondPosition == inputLine.RepeatingLetter ||
                    firstPosition != inputLine.RepeatingLetter && secondPosition != inputLine.RepeatingLetter)
                {
                    isValidPassword = false;
                }
                else
                {
                    isValidPassword = true;
                }

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
                                   FirstPosition = int.Parse(matches[0].Groups[1].Value),
                                   SecondPosition = int.Parse(matches[0].Groups[2].Value),
                                   RepeatingLetter = matches[0].Groups[3].Value,
                                   Password = matches[0].Groups[4].Value
                               });
            }

            return inputLines;
        }

        private class InputLine
        {
            public int FirstPosition { get; set; }
            public int SecondPosition { get; set; }
            public string RepeatingLetter { get; set; }
            public string Password { get; set; }
        }
    }
}
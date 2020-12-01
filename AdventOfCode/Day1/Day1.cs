using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day1
{
    public class Day1
    {
        public static void Run(string filePath)
        {
            var expenses = ReadIntsFromFile(filePath);

            var numbersAddingTo2020 = FindNumbersAddingTo2020(expenses);

            var multipliedNumbers = numbersAddingTo2020.FirstNumber * numbersAddingTo2020.SecondNumber;

            Console.WriteLine("Multiplied result: " + multipliedNumbers);
        }

        private static NumbersAddingTo2020 FindNumbersAddingTo2020(IEnumerable<int> expenses)
        {
            var enumeratedArray = expenses as int[] ?? expenses.ToArray();

            foreach (var expense in enumeratedArray)
            {
                var partnerNumber = 2020 - expense;
                if (enumeratedArray.Contains(partnerNumber))
                {
                    return new NumbersAddingTo2020(expense, partnerNumber);
                }
            }

            throw new NoMatchingNumbersFoundException();
        }

        private static IEnumerable<int> ReadIntsFromFile(string testInputFile)
        {
            var lineArray = File.ReadAllLines($"./Day1/{testInputFile}");
            return lineArray.Select(int.Parse);
        }

        public record NumbersAddingTo2020(int FirstNumber, int SecondNumber);

    }
}

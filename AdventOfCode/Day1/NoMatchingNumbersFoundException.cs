using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day1
{
    public class NoMatchingNumbersFoundException : Exception
    {
        public NoMatchingNumbersFoundException()
        {
        }

        public NoMatchingNumbersFoundException(string message) : base(message) { }
    }
}

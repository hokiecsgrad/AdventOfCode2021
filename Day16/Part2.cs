using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode2021.Day16
{
    public class Part2
    {
        public void Run(string[] data)
        {
            Parser parser = new Parser();

            string binaryString = parser.ConvertHexToBinary(data[0]);
            (long versionTotal, long numBits) = parser.ParsePacket(binaryString);

            long result = parser.Calculate();

            System.Console.WriteLine($"The value of all operations is: {result}");
        }
    }
}

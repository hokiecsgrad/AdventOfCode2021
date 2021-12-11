using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day10
{
    public class Parser
    {
        private string OpenSymbols = "([{<";
        private string ClosedSymbols = ")]}>";
        Stack<char> Symbols = new();

        public Parser()
        {
            ResetSymbols();
        }

        private void ResetSymbols()
        {
            Symbols = new();
        }

        public string CompleteLine(string line)
        {
            (bool isCorrupted, char _) = HasCorruptedChunk(line);
            if (isCorrupted) return string.Empty;

            string endOfLine = string.Empty;
            while (Symbols.Count() > 0)
                endOfLine += ClosedSymbols[OpenSymbols.IndexOf(Symbols.Pop())];

            return endOfLine;
        }

        public (bool, char) HasCorruptedChunk(string candidate)
        {
            ResetSymbols();
            for (int i = 0; i < candidate.Length; i++)
            {
                if (OpenSymbols.Contains(candidate[i]))
                    Symbols.Push(candidate[i]);
                else if (ClosedSymbols.Contains(candidate[i]))
                {
                    char lastChar = Symbols.Pop();
                    if (ClosedSymbols.IndexOf(candidate[i]) != OpenSymbols.IndexOf(lastChar))
                        return (true, candidate[i]);
                }
            }
            return (false, ' ');
        }
    }
}
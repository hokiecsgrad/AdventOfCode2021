using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Day14
{
    public class Polymer
    {
        public Dictionary<string, long> PairInsertion(string startingTemplate, Dictionary<string, string> instructions, int numSteps, int window = 2)
        {
            Dictionary<string, long> templateForLoop = new();
            for (int i = 0; i <= startingTemplate.Length - window; i++)
            {
                string currPair = startingTemplate.Substring(i,window);
                if (templateForLoop.ContainsKey(currPair))
                    templateForLoop[currPair]++;
                else
                    templateForLoop.Add(currPair, 1L);
            }

            for (int i = 0; i < numSteps; i++)
            {
                Dictionary<string, long> currPairs = new();
                foreach (var pair in templateForLoop)
                {
                    string poly = pair.Key[0] + instructions[pair.Key] + pair.Key[1];
                    for (int j = 0; j < 2; j++)
                    {
                        string currPair = poly.Substring(j,window);
                        if (currPairs.ContainsKey(currPair))
                            currPairs[currPair] += pair.Value;
                        else
                            currPairs.Add(currPair, pair.Value);
                    }
                }
                templateForLoop = currPairs;
            }
            return templateForLoop;
        }

        public Dictionary<char, long> CountLetters(string startingTemplate, Dictionary<string, long> pairs)
        {
            Dictionary<char, long> letterCounts = new();
            foreach (var occurance in pairs)
            {
                char letter = occurance.Key[0];
                if (letterCounts.ContainsKey(letter))
                    letterCounts[letter] += occurance.Value;
                else
                    letterCounts.Add(letter, occurance.Value);
            }
            letterCounts[startingTemplate.Last()] += 1;

            return letterCounts;
        }

    }
}
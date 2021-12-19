using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Day16
{
    public class Parser
    {
        public string[] _data;
        Stack<(int op, long val)> _rpn = new();

        public Parser() { _data = new string[] { }; }

        public Parser(string[] data)
        {
            _data = new string[data.Length];
            for (int i = 0; i < data.Length; i++)
                _data[i] = data[i];
        }

        public long Calculate()
        {
            long result = Rpn(_rpn);
            return result;
        }

        private long Rpn(Stack<(int,long)> rpn)
        {
            int op = -1;
            long total = 0;
            List<long> values = new();
            while (_rpn.Count() > 0)
            {
                (op, long val) = _rpn.Pop();
                if (op == -1)
                    values.Add(val);
                else if (op == 99)
                {
                    values.Add( Rpn(rpn) );
                }
                else if (op == 98)
                {
                    return values[0];
                }
                else
                {
                    total = op switch
                    {
                        0 => values.Sum(),
                        1 => values.Aggregate(1L, (curr, next) => curr * next),
                        2 => values.Min(),
                        3 => values.Max(),
                        5 => values[1] > values[0] ? 1 : 0,
                        6 => values[1] < values[0] ? 1 : 0,
                        7 => values[1] == values[0] ? 1 : 0,
                        _ => throw new NotImplementedException(),
                    };
                    values = new List<long>();
                    values.Add(total);
                }
            }
            return values[0];
        }

        public long Parse()
        {
            long sumOfVersions = 0;
            for (int i = 0; i < _data.Length; i++)
            {
                string binaryString = ConvertHexToBinary(_data[i]);
                (long versionSum, long numBitsProcessed) = ParsePacket(binaryString);
                sumOfVersions += versionSum;
            }
            return sumOfVersions;
        }

        public (long, long) ParsePacket(string binaryString)
        {
            string currString = binaryString;
            long sumOfVersions = 0;
            long totalBitsProcessed = 0;

            (long version, int type, long numBitsProccessed) = ParsePacketHeader(currString);
            sumOfVersions += version;
            totalBitsProcessed += numBitsProccessed;

            currString = currString.Substring(Convert.ToInt32(numBitsProccessed));
            if (type == 4)
            {
                (long value, numBitsProccessed) = ParseLiteralPacket(currString);
                _rpn.Push((-1, value));
            }
            else
            {
                _rpn.Push((98,-1));
                _rpn.Push((type, -1));
                (version, numBitsProccessed) = ParseOperatorPacket(currString);
                _rpn.Push((99,-1));
                sumOfVersions += version;
            }
            totalBitsProcessed += numBitsProccessed;

            return (sumOfVersions, totalBitsProcessed);
        }

        public (int, int, int) ParsePacketHeader(string binaryString)
        {
            int version = Convert.ToInt32(binaryString.Substring(0, 3), 2);
            int typeId = Convert.ToInt32(binaryString.Substring(3, 3), 2);
            return (version, typeId, 6);
        }

        public (long, long) ParseOperatorPacket(string binaryString)
        {
            long sumOfVersions = 0;
            long totalBitsProcessed = 0;

            char modeBit = binaryString[0];
            totalBitsProcessed += 1;

            long currBitsProcessed = 0;
            string currString = binaryString.Substring(Convert.ToInt32(totalBitsProcessed));
            if (modeBit == '0')
                (sumOfVersions, currBitsProcessed) = ParseOperatorModeZero(currString);
            else
                (sumOfVersions, currBitsProcessed) = ParseOperatorModeOne(currString);
            totalBitsProcessed += currBitsProcessed;

            return (sumOfVersions, totalBitsProcessed);
        }

        public (long, long) ParseOperatorModeZero(string binaryString)
        {
            long sumOfVersions = 0;
            long totalLengthInBits = Convert.ToInt32(binaryString.Substring(0, 15), 2);
            long currBitsProcessed = 0;
            long totalBitsProcessed = 15;

            string currString = binaryString.Substring(Convert.ToInt32(totalBitsProcessed));
            while (currBitsProcessed < totalLengthInBits)
            {
                (long version, long numBitsProcessed) = ParsePacket(currString);
                currString = currString.Substring(Convert.ToInt32(numBitsProcessed));
                currBitsProcessed += numBitsProcessed;
                sumOfVersions += version;
            }
            totalBitsProcessed += currBitsProcessed;

            return (sumOfVersions, totalBitsProcessed);
        }

        public (long, long) ParseOperatorModeOne(string binaryString)
        {
            long sumOfVersions = 0;
            long numSubPackets = Convert.ToInt32(binaryString.Substring(0, 11), 2);
            long totalBitsProcessed = 11;

            string currString = binaryString.Substring(Convert.ToInt32(totalBitsProcessed));
            for (int packetIndex = 0; packetIndex < numSubPackets; packetIndex++)
            {
                (long version, long numBitsProcessed) = ParsePacket(currString);
                currString = currString.Substring(Convert.ToInt32(numBitsProcessed));
                totalBitsProcessed += numBitsProcessed;
                sumOfVersions += version;
            }

            return (sumOfVersions, totalBitsProcessed);
        }

        public (long, long) ParseLiteralPacket(string binaryString)
        {
            string curr = binaryString;
            StringBuilder result = new StringBuilder(curr.Substring(1, 4));
            long numBitsProcessed = 5;
            while (curr[0] != '0')
            {
                curr = curr.Substring(5);
                result.Append(curr.Substring(1, 4));
                numBitsProcessed += 5;
            }
            return (Convert.ToInt64(result.ToString(), 2), numBitsProcessed);
        }

        public string ConvertHexToBinary(string hexString)
            => String.Join(String.Empty,
                            hexString.Select(
                                c => Convert.ToString(
                                    Convert.ToInt32(c.ToString(), 16), 2
                                )
                                .PadLeft(4, '0')
                            ));
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode2021.Day16;
using Xunit;

namespace AdventOfCode2021.Day16.Tests
{
    public class Day16Tests
    {
        [Fact]
        public void Parser_WithExampleInputD2FE28_ShouldReturnBinaryString110100101111111000101000()
        {
            string[] data = new string[] { "D2FE28" };
            Parser parser = new Parser();

            Assert.Equal("110100101111111000101000", parser.ConvertHexToBinary("D2FE28"));
        }

        [Fact]
        public void ParseLiteralPacket_WithExampleInput110100101111111000101000_ShouldReturnLiteralValue2021()
        {
            Parser parser = new Parser();

            string sample = "110100101111111000101000";
            (long version, int type, long numBits) = parser.ParsePacketHeader(sample);

            Assert.Equal(6, version);
            Assert.Equal(4, type);
            Assert.Equal(6, numBits);

            (long value, numBits) = parser.ParseLiteralPacket(sample.Substring(Convert.ToInt32(numBits)));

            Assert.Equal(2021, value);
            Assert.Equal(15, numBits);
        }

        [Fact]
        public void ParseOperatorPacket_WithExampleInputId0_ShouldReturnTwoLiterals10And20()
        {
            Parser parser = new Parser();

            string sample = "00111000000000000110111101000101001010010001001000000000";
            (long version, int type, long numBits) = parser.ParsePacketHeader(sample);

            Assert.Equal(1, version);
            Assert.Equal(6, type);
            Assert.Equal(6, numBits);

            (version, numBits) = parser.ParseOperatorPacket(sample.Substring(Convert.ToInt32(numBits)));

            Assert.Equal(8, version);
            Assert.Equal(43, numBits);
        }

        [Fact]
        public void ParseOperatorPacket_WithExampleInputId1_ShouldReturn14()
        {
            long totalVersion = 0;
            Parser parser = new Parser();

            string sample = "11101110000000001101010000001100100000100011000001100000";
            (long version, int type, long numBits) = parser.ParsePacketHeader(sample);
            totalVersion += version;

            Assert.Equal(7, version);
            Assert.Equal(3, type);
            Assert.Equal(6, numBits);

            (version, numBits) = parser.ParseOperatorPacket(sample.Substring(Convert.ToInt32(numBits)));
            totalVersion += version;

            Assert.Equal(7, version);
            Assert.Equal(45, numBits);

            Assert.Equal(14, totalVersion);
        }

        [Fact]
        public void Part1_WithSampleHexString8A004A801A8002F478_ShouldReturn16()
        {
            string sample = "8A004A801A8002F478";
            Parser parser = new Parser();

            string binaryString = parser.ConvertHexToBinary(sample);
            // 100010100000000001001010100000000001101010000000000000101111010001111000
            // VVVTTTILLLLLLLLLLLVVVTTTILLLLLLLLLLLVVVTTTILLLLLLLLLLLLLLLVVVTTTAAAAA
            (long versionTotal, long numBits) = parser.ParsePacket(binaryString);

            Assert.Equal(16, versionTotal);
            Assert.Equal(69, numBits);
        }

        [Fact]
        public void Part1_WithSampleHexString620080001611562C8802118E34_ShouldReturn12()
        {
            string sample = "620080001611562C8802118E34";
            Parser parser = new Parser();

            string binaryString = parser.ConvertHexToBinary(sample);
            (long versionTotal, long numBits) = parser.ParsePacket(binaryString);

            Assert.Equal(12, versionTotal);
        }

        [Fact]
        public void Part1_WithSampleHexStringC0015000016115A2E0802F182340_ShouldReturn23()
        {
            string sample = "C0015000016115A2E0802F182340";
            Parser parser = new Parser();

            string binaryString = parser.ConvertHexToBinary(sample);
            (long versionTotal, long numBits) = parser.ParsePacket(binaryString);

            Assert.Equal(23, versionTotal);
        }

        [Fact]
        public void Part1_WithSampleHexStringA0016C880162017C3686B18A3D4780_ShouldReturn31()
        {
            string sample = "A0016C880162017C3686B18A3D4780";
            Parser parser = new Parser();

            string binaryString = parser.ConvertHexToBinary(sample);
            (long versionTotal, long numBits) = parser.ParsePacket(binaryString);

            Assert.Equal(31, versionTotal);
        }

        [Fact]
        public void Calculator_WithExampleHexStringC200B40A82_ShouldReturn3()
        {
            string sample = "C200B40A82";
            Parser parser = new Parser();

            string binaryString = parser.ConvertHexToBinary(sample);
            (long versionTotal, long numBits) = parser.ParsePacket(binaryString);

            long result = parser.Calculate();

            Assert.Equal(3, result);
        }

        [Fact]
        public void Calculator_WithExampleHexString04005AC33890_ShouldReturn54()
        {
            string sample = "04005AC33890";
            Parser parser = new Parser();

            string binaryString = parser.ConvertHexToBinary(sample);
            (long versionTotal, long numBits) = parser.ParsePacket(binaryString);

            long result = parser.Calculate();

            Assert.Equal(54, result);
        }

        [Fact]
        public void Calculator_WithExampleHexString880086C3E88112_ShouldReturn7()
        {
            string sample = "880086C3E88112";
            Parser parser = new Parser();

            string binaryString = parser.ConvertHexToBinary(sample);
            (long versionTotal, long numBits) = parser.ParsePacket(binaryString);

            long result = parser.Calculate();

            Assert.Equal(7, result);
        }

        [Fact]
        public void Calculator_WithExampleHexStringCE00C43D881120_ShouldReturn9()
        {
            string sample = "CE00C43D881120";
            Parser parser = new Parser();

            string binaryString = parser.ConvertHexToBinary(sample);
            (long versionTotal, long numBits) = parser.ParsePacket(binaryString);

            long result = parser.Calculate();

            Assert.Equal(9, result);
        }

        [Fact]
        public void Calculator_WithExampleHexStringD8005AC2A8F0_ShouldReturn1()
        {
            string sample = "D8005AC2A8F0";
            Parser parser = new Parser();

            string binaryString = parser.ConvertHexToBinary(sample);
            (long versionTotal, long numBits) = parser.ParsePacket(binaryString);

            long result = parser.Calculate();

            Assert.Equal(1, result);
        }

        [Fact]
        public void Calculator_WithExampleHexStringF600BC2D8F_ShouldReturn0()
        {
            string sample = "F600BC2D8F";
            Parser parser = new Parser();

            string binaryString = parser.ConvertHexToBinary(sample);
            (long versionTotal, long numBits) = parser.ParsePacket(binaryString);

            long result = parser.Calculate();

            Assert.Equal(0, result);
        }

        [Fact]
        public void Calculator_WithExampleHexString9C005AC2F8F0_ShouldReturn0()
        {
            string sample = "9C005AC2F8F0";
            Parser parser = new Parser();

            string binaryString = parser.ConvertHexToBinary(sample);
            (long versionTotal, long numBits) = parser.ParsePacket(binaryString);

            long result = parser.Calculate();

            Assert.Equal(0, result);
        }

        [Fact]
        public void Calculator_WithExampleHexString9C0141080250320F1802104A08_ShouldReturn1()
        {
            string sample = "9C0141080250320F1802104A08";
            Parser parser = new Parser();

            string binaryString = parser.ConvertHexToBinary(sample);
            (long versionTotal, long numBits) = parser.ParsePacket(binaryString);

            long result = parser.Calculate();

            Assert.Equal(1, result);
        }
    }
}
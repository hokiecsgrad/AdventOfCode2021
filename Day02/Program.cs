﻿using AdventOfCode.Common;

InputGetter input = new InputGetter("input.txt");

ProgramFramework framework = new ProgramFramework();
framework.InputHandler = input.GetStringsFromInput;
framework.Part1Handler = new Part1().Run;
framework.Part2Handler = new Part2().Run;
framework.RunProgram();
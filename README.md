# Advent Of Code 2021

Code for 2021's Advent of Code challenge.

https://adventofcode.com/2021

# Project template

In the directory, `AoCTemplate` you'll find a `dotnet` template structure so that new days can be added easily.  The base usage for this is:

`> dotnet new aoc --name Day01`

This will create a directory structure that looks like the following:
```
Day01\
 --Day01.csproj
 --Program.cs
 --Part1.cs
 --Part2.cs
 --input.txt
 --tests\
   --tests.csproj
   --Day01Tests.cs
```

## Running tests

`> dotnet test Day01/tests`

## Running that Day's solution

`> dotnet run Day01`

## Un/Installing the Template

To install a template, once you've setup the template directory/structure as per the documentation here 
(https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates), then you can simply run the command

`> dotnet new --install AoCTemplate/`

To make changes to a template, you have to uninstall it and reinstall it.  The uninstall command can be 
found by running 

`> dotnet new --uninstall`.

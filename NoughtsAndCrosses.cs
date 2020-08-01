using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class NoughtsAndCrosses{
    static void Main(string[] args){
        string input;
        Regex command = new Regex(@"\d{1},\d{1}\s[OX]$",
                                  RegexOptions.Compiled |
                                  RegexOptions.IgnoreCase);
        List<List<string>> grid = new List<List<string>>();

        for (int i = 0; i < 3; ++i){
            grid.Add(new List<string>(new string[] {null, null, null}));
        }

        NAndCrosses.printGrid(grid);
         

        Console.WriteLine("Enter coordinates and a value 'O' or 'X'");
        Console.WriteLine("e.g. '0,1 X'");

        while (true){
            input = Console.ReadLine();
            if (command.Matches(input).Count > 0){
                break;
            }
        }
        Console.WriteLine(input);
        string[] splits = input.Split(',');
        int xCoord = int.Parse(splits[0]);
        int yCoord = int.Parse(splits[1].Split(' ')[0]);
        string noughtOrCross = splits[1].Split(' ')[1];
        //grid.Insert(yCoord, .Insert(xCoord, noughtOrCross);

        NAndCrosses.printGrid(grid);
    }

    static void printGrid(List<List<string>> grid){
        foreach (List<string> row in grid) {
            Console.WriteLine(String.Join(", ", row));
        }
    }

}

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Game{
    class NoughtsAndCrosses{
        static void Main(string[] args){
            string input;
            Regex command = new Regex(@"\d{1},\d{1}\s[OX]$",
                                      RegexOptions.Compiled |
                                      RegexOptions.IgnoreCase);
            Grid grid = new Grid();
            grid.setRow0(new List<string>(new string[] {null, null, null}));
            grid.setRow1(new List<string>(new string[] {null, null, null}));
            grid.setRow2(new List<string>(new string[] {null, null, null}));


            NoughtsAndCrosses.printGrid(grid);
            
            while (grid.notFull()){
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

                if (xCoord < 3){
                    if (yCoord == 0){
                        List<string> newRow = grid.getRow0();
                        newRow[xCoord] = noughtOrCross;
                        grid.setRow0(newRow);
                    } else if (yCoord == 1){
                        List<string> newRow = grid.getRow1();
                        newRow[xCoord] = noughtOrCross;
                        grid.setRow1(newRow);
                    } else if (yCoord == 2){
                        List<string> newRow = grid.getRow2();
                        newRow[xCoord] = noughtOrCross;
                        grid.setRow2(newRow);
                    }
                }
                NoughtsAndCrosses.printGrid(grid);
            }
        }

        static void printGrid(Grid grid){
            Console.WriteLine(String.Join(", ", grid.getRow0()));
            Console.WriteLine(String.Join(", ", grid.getRow1()));
            Console.WriteLine(String.Join(", ", grid.getRow2()));
        }

    }
}

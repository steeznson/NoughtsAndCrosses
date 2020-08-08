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
            
            while (grid.notFull()){
                // exit if win state
                if (grid.win()){
                    grid.print();
                    Console.WriteLine("\n~~GAME OVER~~\n");
                    Environment.Exit(0);
                }

// The CPU takes the first go if enabled
#if CPU
                var rand = new Random();
                bool searching = true;
                while (searching){
                    int cpuXCoord = rand.Next(0, 3);
                    int cpuYCoord = rand.Next(0, 3);
                    switch (cpuYCoord){
                        case 0:
                            List<string> cpuRow0 = grid.getRow0();
                            if (cpuRow0[cpuXCoord] == null){
                                cpuRow0[cpuXCoord] = "O";
                                grid.setRow0(cpuRow0);
                                searching = false;
                            }
                            break;
                        case 1:
                            List<string> cpuRow1 = grid.getRow1();
                            if (cpuRow1[cpuXCoord] == null){
                                cpuRow1[cpuXCoord] = "O";
                                grid.setRow1(cpuRow1);
                                searching = false;
                            }
                            break;
                        case 2:
                            List<string> cpuRow2 = grid.getRow2();
                            if (cpuRow2[cpuXCoord] == null){
                                cpuRow2[cpuXCoord] = "O";
                                grid.setRow2(cpuRow2);
                                searching = false;
                            }
                            break;
                    }
                }
#endif

                grid.print();
                Console.WriteLine("\nEnter coordinates and a value 'O' or 'X'");
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

                /*TODO abstract this functionality to avoid repetition
                  getProperty() using string 'rowX'? */
                if (xCoord < 3){
                    if (yCoord == 0){
                        List<string> newRow = grid.getRow0();
                        if (newRow[xCoord] == null){
                            newRow[xCoord] = noughtOrCross;
                            grid.setRow0(newRow);
                        }
                    } else if (yCoord == 1){
                        List<string> newRow = grid.getRow1();
                        if (newRow[xCoord] == null){
                            newRow[xCoord] = noughtOrCross;
                            grid.setRow1(newRow);
                        }
                    } else if (yCoord == 2){
                        List<string> newRow = grid.getRow2();
                        if (newRow[xCoord] == null){
                            newRow[xCoord] = noughtOrCross;
                            grid.setRow2(newRow);
                        }
                    }
                }
            }
        }
    }
}

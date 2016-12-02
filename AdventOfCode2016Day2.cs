using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    class AdventOfCode2016Day2
    {
        public static List<String> AllPostions = new List<String>();

        public class Position
        {
            public int X, Y;

            public Position()
            {
                this.X = 0;
                this.Y = 0;
            }

            public Position(int xIn, int yIn)
            {
                this.X = xIn;
                this.Y = yIn;
            }

            public override string ToString()
            {
                if (this.X == 0 && this.Y == 2)
                {
                    return "1";
                }
                else if (this.X == -1 && this.Y == 1)
                {
                    return "2";
                }
                else if (this.X == 0 && this.Y == 1)
                {
                    return "3";
                }
                else if (this.X == 1 && this.Y == 1)
                {
                    return "4";
                }
                else if (this.X == -2 && this.Y == 0)
                {
                    return "5";
                }
                else if (this.X == -1 && this.Y == 0)
                {
                    return "6";
                }
                else if (this.X == 0 && this.Y == 0)
                {
                    return "7";
                }
                else if (this.X == 1 && this.Y == 0)
                {
                    return "8";
                }
                else if (this.X == 2 && this.Y == 0)
                {
                    return "9";
                } 
                
                else if (this.X == -1 && this.Y == -1)
                {
                    return "A";
                }
                else if (this.X == 0 && this.Y == -1)
                {
                    return "B";
                }
                else if (this.X == 1 && this.Y == -1)
                {
                    return "C";
                }
                else if (this.X == 0 && this.Y == -2)
                {
                    return "D";
                }
                else 
                {
                    return "NaN";
                }
            }

            public bool Equals(Position pos)
            {
                return this.X == pos.X && this.Y == pos.Y;
            }
        }

        static void Code2016Day2(string[] args)
        {
            Position startingPosition = new Position(-2, 0);
            Position pos = startingPosition;

            Console.Out.WriteLine("Starting position:");
            Console.Out.WriteLine(startingPosition.ToString());

            //var uri = new System.Uri(@"http://adventofcode.com/2016/day/2/input");
            //var webClient = new WebClient();
            //String text = webClient.DownloadString(uri);

            String text = File.ReadAllText(@"C:\Users\Z236\Documents\adventofcode\Day2input.txt");
            string[] instructions = text.Split('\n');

            foreach (var instruction in instructions)
            {
                //Console.WriteLine(instruction);
                foreach (char letter in instruction)
                {
                    switch (letter)
                    {
                        case 'R':
                            pos = MoveRight(pos);
                            break;
                        case 'L':
                            pos = MoveLeft(pos);
                            break;
                        case 'U':
                            pos = MoveUp(pos);
                            break;
                        case 'D':
                            pos = MoveDown(pos);
                            break;
                    }
                    //Console.WriteLine(letter + " " + pos);
                }
                Console.Out.Write(pos.ToString());
            }

            Console.In.Read();
        }

        static public Position MoveRight(Position pos)
        {
            pos.X++;
            if (Math.Abs(pos.X) + Math.Abs(pos.Y) > 2)
            {
                pos.X--;
            }
            return pos;
        }

        static public Position MoveLeft(Position pos)
        {
            pos.X--;
            if (Math.Abs(pos.X) + Math.Abs(pos.Y) > 2)
            {
                pos.X++;
            }
            return pos;
        }

        static public Position MoveUp(Position pos)
        {
            pos.Y++;
            if (Math.Abs(pos.X) + Math.Abs(pos.Y) > 2)
            {
                pos.Y--;
            }
            return pos;
        }

        static public Position MoveDown(Position pos)
        {
            pos.Y--;
            if (Math.Abs(pos.X) + Math.Abs(pos.Y) > 2)
            {
                pos.Y++;
            }
            return pos;
        }
    }
}

namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class AdventOfCode2015Day3
    {
        public static HashSet<String> AllPostions = new HashSet<String>();

        public class Position
        {
            public int X, Y;

            public Position()
            {
                this.X = 0;
                this.Y = 0;
            }

            public Position(int xIn, int yIn, char directionIn)
            {
                this.X = xIn;
                this.Y = yIn;
            }

            public override string ToString()
            {
                return "X:" + X.ToString() + " Y:" + Y.ToString();
            }
        }

        static void Code2015Day3(string[] args)
        {
            int total = 0;
            int duplicates = 0;
            Position santa = new Position();
            Position robosanta = new Position();
            AllPostions.Add(santa.ToString());
            //var uri = new System.Uri(@"http://adventofcode.com/2015/day/3/input");
            //var webClient = new WebClient();
            //String text = webClient.DownloadString(uri);

            String text = File.ReadAllText(@"C:\Users\Z236\Documents\adventofcode\2015Day3input.txt");
            int i = 0;
            foreach (var instruction in text.ToCharArray())
            {
                if (i % 2 == 0)
                {
                    switch (instruction)
                    {
                        case '<':
                            santa = MoveWest(santa);
                            break;
                        case '>':
                            santa = MoveEast(santa);
                            break;
                        case '^':
                            santa = MoveNorth(santa);
                            break;
                        case 'v':
                            santa = MoveSouth(santa);
                            break;
                    }
                }
                else
                {
                    switch (instruction)
                    {
                        case '<':
                            robosanta = MoveWest(robosanta);
                            break;
                        case '>':
                            robosanta = MoveEast(robosanta);
                            break;
                        case '^':
                            robosanta = MoveNorth(robosanta);
                            break;
                        case 'v':
                            robosanta = MoveSouth(robosanta);
                            break;
                    }
                }
                i++;
            }
            var duplicateKeys = AllPostions.GroupBy(x => x)
                        .Where(group => group.Count() > 1)
                        .Select(group => group.Key);
            foreach (var duplicate in duplicateKeys)
            {
                duplicates++;
                Console.Out.WriteLine(duplicate);
            }
            total = AllPostions.Count;
            Console.Out.WriteLine(total);
            Console.In.Read();
        }

        static public Position MoveNorth(Position pos)
        {
            pos.Y++;
            AllPostions.Add(pos.ToString());
            return pos;
        }
        static public Position MoveSouth(Position pos)
        {
            pos.Y--;
            AllPostions.Add(pos.ToString());
            return pos;
        }
        static public Position MoveEast(Position pos)
        {
            pos.X++;
            AllPostions.Add(pos.ToString());
            return pos;
        }
        static public Position MoveWest(Position pos)
        {
            pos.X--;
            AllPostions.Add(pos.ToString());
            return pos;
        }
    }
}

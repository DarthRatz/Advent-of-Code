using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    class AdventOfCode2016Day1
    {
        public static List<String> AllPostions = new List<String>();

        public struct position
        {
            public int X, Y;
            public char Direction;

            /*public position()
            {
                this.X = 0;
                this.Y = 0;
                this.Direction = 'N';
            }*/

            public position(int xIn, int yIn, char directionIn)
            {
                this.X = xIn;
                this.Y = yIn;
                this.Direction = directionIn;
            }  

            public override string ToString()
            {
                return "X:"+X.ToString() + " Y:" + Y.ToString();
            }

            public bool Equals(position pos)
            {
                return X == pos.X && Y == pos.Y;
            }


        } 

        static void Main(string[] args)
        {
            position startingPosition = new position(0,0,'N');
            position pos = startingPosition;

            Console.Out.WriteLine("Starting position: " + startingPosition.ToString());
            string text = File.ReadAllText(@"C:\Users\Z236\Documents\adventofcode\Day1input.txt");
            //string text = File.ReadAllText(@"C:\Users\Z236\Documents\adventofcode\Day1test.txt");
            string[] instructions = text.Split(',');

            foreach (var instruction in instructions)
            {
                //Console.WriteLine(instruction);
                switch (instruction[0])
                {
                    case 'R':
                        pos = MoveRight(pos, Convert.ToInt32(instruction.Substring(1)));
                        break;
                    case 'L':
                        pos = MoveLeft(pos, Convert.ToInt32(instruction.Substring(1)));
                        break;
                }
            }
            Console.WriteLine("Final Position:");
            Console.Out.WriteLine(pos.ToString());

            Console.WriteLine("First Duplicate:");
            var duplicateKeys = AllPostions.GroupBy(x => x)
                        .Where(group => group.Count() > 1)
                        .Select(group => group.Key);
            foreach (var duplicate in duplicateKeys)
            {
                Console.WriteLine(duplicate);
                break;
            }

            /*pos = MoveRight(pos, 5);
            pos = MoveLeft(pos, 5);
            pos = MoveRight(pos, 5);
            pos = MoveRight(pos, 3);
            */
            
            
            Console.In.Read();
        }

        static public position MoveRight(position pos, int distance)
        {
            if (pos.Direction == 'N')
            {
                for (int i = 0; i < distance; i++)
                {
                    pos.X += 1;
                    AllPostions.Add(pos.ToString());
                }
                pos.Direction = 'E';
            }
            else if (pos.Direction == 'S')
            {
                for (int i = 0; i < distance; i++)
                {
                    pos.X -= 1;
                    AllPostions.Add(pos.ToString());
                }
                pos.Direction = 'W';
            }
            else if (pos.Direction == 'E')
            {
                for (int i = 0; i < distance; i++)
                {
                    pos.Y -= 1;
                    AllPostions.Add(pos.ToString());
                }
                pos.Direction = 'S';
            }
            else if (pos.Direction == 'W')
            {
                for (int i = 0; i < distance; i++)
                {
                    pos.Y += 1;
                    AllPostions.Add(pos.ToString());
                }
                pos.Direction = 'N';
            }

            //.Out.WriteLine(pos.ToString());
            return pos;
        }

        static public position MoveLeft(position pos, int distance)
        {
            if (pos.Direction == 'N')
            {
                for (int i = 0; i < distance; i++)
                {
                    pos.X -= 1;
                    AllPostions.Add(pos.ToString());
                }
                pos.Direction = 'W';
            }
            else if (pos.Direction == 'S')
            {
                for (int i = 0; i < distance; i++)
                {
                    pos.X += 1;
                    AllPostions.Add(pos.ToString());
                }
                pos.Direction = 'E';
            }
            else if (pos.Direction == 'E')
            {
                for (int i = 0; i < distance; i++)
                {
                    pos.Y += 1;
                    AllPostions.Add(pos.ToString());
                }
                pos.Direction = 'N';
            }
            else if (pos.Direction == 'W')
            {
                for (int i = 0; i < distance; i++)
                {
                    pos.Y -= 1;
                    AllPostions.Add(pos.ToString());
                }
                pos.Direction = 'S';
            }

            //Console.Out.WriteLine(pos.ToString());
            return pos;
        }
    }
}

namespace AdventOfCode2018
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program{

        static void Main(string[] args)
        {
            int pos = 0;
            bool duplicateFound = false;
            Console.Out.WriteLine("Starting position: " + pos);

            //var uri = new System.Uri(@"http://adventofcode.com/2015/day/1/input");
            //var webClient = new WebClient();
            //String text = webClient.DownloadString(uri);

            string text = File.ReadAllText(@"C:\Users\Z236\Documents\adventofcode\2018Day1input.txt");
            //string text = File.ReadAllText(@"C:\Users\Z236\Documents\adventofcode\Day1test.txt");

            string[] instructions = text.Split('\n');

            HashSet<int> listOfPos = new HashSet<int> { pos };

            while (duplicateFound == false)
            {
                foreach (string instruction in instructions)
                {
                    switch (instruction[0])
                    {
                        case '+':
                            pos += MoveUp(instruction);
                            break;
                        case '-':
                            pos += MoveDown(instruction);
                            break;
                    }

                    if (listOfPos.Contains(pos))
                    {
                        duplicateFound = true;
                        Console.WriteLine("First Pos hit twice:");
                        Console.Out.WriteLine(pos);
                        Console.In.Read();
                    }

                    listOfPos.Add(pos);
                }
            }

            Console.WriteLine("Final Position:");
            Console.Out.WriteLine(pos);

            Console.In.Read();
        }

        private static int MoveUp(string instruction)
        {
            int pos = int.Parse(instruction.TrimStart('+'));
            return pos;
        }

        private static int MoveDown(string instruction)
        {
            int pos = int.Parse(instruction.TrimStart('-'));
            return -pos;
        }
    }
}


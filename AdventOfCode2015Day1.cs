using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    class AdventOfCode2015Day1
    {

        static void Main(string[] args)
        {
            int pos = 0;
            Console.Out.WriteLine("Starting position: " + pos);

            //var uri = new System.Uri(@"http://adventofcode.com/2015/day/1/input");
            //var webClient = new WebClient();
            //String text = webClient.DownloadString(uri);

            String text = File.ReadAllText(@"C:\Users\Z236\Documents\adventofcode\Day1input.txt");
            //string text = File.ReadAllText(@"C:\Users\Z236\Documents\adventofcode\Day1test.txt");



            foreach (char instruction in text)
            {
                switch (instruction)
                {
                    case '(':
                        pos = MoveUp(pos);
                        break;
                    case ')':
                        pos = MoveDown(pos);
                        break;
                }
            }
            Console.WriteLine("Final Position:");
            Console.Out.WriteLine(pos);
            
            pos = 0;
            for (int i = 0; i < text.Length; i++)
            {
                switch (text.ElementAt(i))
                {
                    case '(':
                        pos = MoveUp(pos);
                        break;
                    case ')':
                        pos = MoveDown(pos);
                        break;
                }

                if (pos < 0)
                {
                    Console.WriteLine("The instruction that sends Santa to the basement is");
                    Console.WriteLine(i);
                    i = text.Length;
                }
            }

            Console.In.Read();
        }
        
        static public int MoveUp(int pos)
        {
            pos++;
            return pos;
        }

        static public int MoveDown(int pos)
        {
            pos--;
            return pos;
        }
    }
}

using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    class AdventOfCode2016Day3
    {
        static void Code2016Day3(string[] args)
        {
            //var uri = new System.Uri(@"http://adventofcode.com/2016/day/3/input");
            //var webClient = new WebClient();
            //String text = webClient.DownloadString(uri);

            String text = File.ReadAllText(@"C:\Users\Z236\Documents\adventofcode\Day3input.txt");
            string[] instructions = text.Split('\n');
            int count = 0;

            foreach (string instruction in instructions)
            {
                //Console.Out.WriteLine(instruction);
                if (checkTriangle(instruction))
                {
                    count++;
                }
            }
            Console.Out.WriteLine(count);

            instructions = text.Split(' ');
            count = 0;
            List<int> i = new List<int>();

            foreach (string instruction in instructions)
            {
                string[] str = instruction.Split(' ');
                

                foreach (string s in str)
                {
                    if (s != string.Empty)
                    {
                        i.Add(Convert.ToInt32(s));
                    }
                }
            }
            for (int j = 0; j < i.Count-6; j++)
            {
                if (j % 9 < 3)
                {
                    if (checkTriangle(i.ElementAt(j), i.ElementAt(j + 3), i.ElementAt(j + 6)))
                    {
                        count++;
                    }
                }
            }

            Console.Out.WriteLine(count);
            Console.In.Read();
        }

        private static bool checkTriangle(string instruction)
        {
            string[] str = instruction.Split(' ');
            List<int> i = new List<int>();

            foreach (string s in str)
            {
                if (s != string.Empty)
                {
                    i.Add(Convert.ToInt32(s));
                }
            }

            i.Sort();
            if (i.ElementAt(0) + i.ElementAt(1) > i.ElementAt(2))
            {
                //Console.Out.WriteLine("a:" + i.ElementAt(0) + " b:" + i.ElementAt(1) + " c:" + i.ElementAt(2));
                return true;
            }
            return false;
        }

        private static bool checkTriangle(int a, int b, int c)
        {
            List<int> i = new List<int>();

            i.Add(a);
            i.Add(b);
            i.Add(c);

            i.Sort();
            if (i.ElementAt(0) + i.ElementAt(1) > i.ElementAt(2))
            {
                //Console.Out.WriteLine("a:" + i.ElementAt(0) + " b:" + i.ElementAt(1) + " c:" + i.ElementAt(2));
                return true;
            }
            return false;
        }
    }
}

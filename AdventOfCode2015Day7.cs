namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class AdventOfCode2015Day7
    {
        static void Main(string[] args)
        {
            //var uri = new System.Uri(@"http://adventofcode.com/2015/day/7/input");
            //var webClient = new WebClient();
            //String text = webClient.DownloadString(uri);

            //String text = File.ReadAllText(@"C:\Users\Z236\Documents\adventofcode\2015Day7input.txt");
            String text = File.ReadAllText(@"C:\Users\Z236\Documents\adventofcode\2015Day7test.txt");
            string[] instructions = text.Split('\n');
            
            List<int> gates = new List<int>();
            int i;
            foreach (var instruction in instructions)
            {
                if (int.TryParse(instruction.Split(' ')[0], out i))
                {
                    gates.Add(i);
                }

            }
            foreach (int gate in gates)
            {
                Console.Out.WriteLine(gate);
            }
            

            Console.In.Read();
        }
    }
}

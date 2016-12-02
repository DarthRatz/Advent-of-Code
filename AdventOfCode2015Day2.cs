using System;
using System.Net;
using System.IO;
using System.Linq;

namespace ConsoleApplication1
{
    class AdventOfCode2015Day2
    {
        public class Dimension
        {
            public int[] dimensions = new int[3];

            public Dimension(int Length, int Width, int Height)
            {
                dimensions[0] = Length;
                dimensions[1] = Width;
                dimensions[2] = Height;
            }
            public Dimension(string Length, string Width, string Height)
            {
                dimensions[0] = Convert.ToInt32(Length);
                dimensions[1] = Convert.ToInt32(Width);
                dimensions[2] = Convert.ToInt32(Height);
            }

        }

        static void Code2015Day2(string[] args)
        {
            int total = 0;
            //var uri = new System.Uri(@"http://adventofcode.com/2015/day/2/input");
            //var webClient = new WebClient();
            //String text = webClient.DownloadString(uri);

            String text = File.ReadAllText(@"C:\Users\Z236\Documents\adventofcode\2015Day2input.txt");

            string[] instructions = text.Split(',');

            foreach (var instruction in instructions)
            {
                string[] dimensions = instruction.Split('x');
                Dimension d = new Dimension(dimensions[0], dimensions[1], dimensions[2]);
                //total += GetWrapping(d);
                total += GetRibbon(d);
            }
            Console.Out.WriteLine(total);
            Console.In.Read();
        }

        static public int GetWrapping(Dimension d)
        {
            int i = 2 * d.dimensions[0] * d.dimensions[1] + 2 * d.dimensions[1] * d.dimensions[2] + 2 * d.dimensions[2] * d.dimensions[0];
            i+= d.dimensions.Min() * d.dimensions.OrderBy(num => num).ElementAt(1);
            return i;
        }

        static public int GetRibbon(Dimension d)
        {
            int i = d.dimensions.Min() + d.dimensions.Min() + d.dimensions.OrderBy(num => num).ElementAt(1) + d.dimensions.OrderBy(num => num).ElementAt(1);
            i += d.dimensions[0] * d.dimensions[1] * d.dimensions[2];
            return i;
        }

    }
}

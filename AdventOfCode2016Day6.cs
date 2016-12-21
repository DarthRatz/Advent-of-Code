namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security.Cryptography;
    using System.Linq;
    using System.Text;

    public class AdventOfCode2016Day6
    {
        public class Frequancy
        {
            public char letter { get; set; }
            public int count { get; set; }

            public Frequancy(char letter, int count)
            {
                this.letter = letter;
                this.count = count;
            }
        }

        private static void Code2016Day6(string[] args)
        {
            //var uri = new System.Uri(@"http://adventofcode.com/2016/day/6/input");
            //var webClient = new WebClient();
            //String text = webClient.DownloadString(uri);

            String text = File.ReadAllText(@"C:\Users\Z236\Documents\adventofcode\Day6input.txt");
            //String text = File.ReadAllText(@"C:\Users\Z236\Documents\adventofcode\Day6test.txt");
            string[] instructions = text.Split('\n');

            StringBuilder[] sb = new StringBuilder[8];
            for (int ix = 0; ix < 8; ++ix)
            {
                sb[ix] = new StringBuilder();
            }

            foreach (var instruction in instructions)
            {
                for (int i = 0; i < 8; i++)
                {
                    sb[i].Append(instruction.Substring(0, 8)[i]);
                }
            }

            foreach (StringBuilder stringBuilder in sb)
            {
                Console.Out.Write(CheckFrequancy(stringBuilder.ToString()));
            }
            Console.Out.WriteLine();

            foreach (StringBuilder stringBuilder in sb)
            {
                Console.Out.Write(CheckLeastFrequancy(stringBuilder.ToString()));
            }
            Console.Out.WriteLine();

            Console.In.Read();
        }

        private static char CheckFrequancy(string term)
        {
            List<Frequancy> f = new List<Frequancy>();
            int[] c = new int[(int)char.MaxValue];
            foreach (char t in term)
            {
                c[(int)t]++;
            }

            for (int i = 0; i < (int)char.MaxValue; i++)
            {
                if (c[i] > 0 && char.IsLetter((char)i))
                {
                    f.Add(new Frequancy((char)i, c[i]));

                }
            }

            f = f.OrderByDescending(a => a.count).ToList();
            StringBuilder result = new StringBuilder();
            foreach (Frequancy frequancy in f)
            {
                result.Append(frequancy.letter);
                //Console.WriteLine(frequancy.letter + " " + frequancy.count);
            }
            return result.ToString()[0];
        }

        private static char CheckLeastFrequancy(string term)
        {
            List<Frequancy> f = new List<Frequancy>();
            int[] c = new int[(int)char.MaxValue];
            foreach (char t in term)
            {
                c[(int)t]++;
            }

            for (int i = 0; i < (int)char.MaxValue; i++)
            {
                if (c[i] > 0 && char.IsLetter((char)i))
                {
                    f.Add(new Frequancy((char)i, c[i]));

                }
            }

            f = f.OrderBy(a => a.count).ToList();
            StringBuilder result = new StringBuilder();
            foreach (Frequancy frequancy in f)
            {
                result.Append(frequancy.letter);
                //Console.WriteLine(frequancy.letter + " " + frequancy.count);
            }
            return result.ToString()[0];
        }
    }
}
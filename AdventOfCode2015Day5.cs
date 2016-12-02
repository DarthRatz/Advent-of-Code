// -----------------------------------------------------------------------
// <copyright file="AdventOfCode2015Day5.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class AdventOfCode2015Day5
    {
        static void Code2015Day5(string[] args)
        {
            int niceCount = 0;

            //var uri = new System.Uri(@"http://adventofcode.com/2015/day/5/input");
            //var webClient = new WebClient();
            //String text = webClient.DownloadString(uri);

            String text = File.ReadAllText(@"C:\Users\Z236\Documents\adventofcode\2015Day5input.txt");
            //String text = File.ReadAllText(@"C:\Users\Z236\Documents\adventofcode\2015Day5test.txt");
            string[] instructions = text.Split('\n');

            foreach (var instruction in instructions)
            {
                if (isNice(instruction))
                {
                    niceCount++;
                    //Console.Out.WriteLine(instruction);
                }
                else
                {
                    //Console.Out.WriteLine(instruction);
                }
            }
            Console.Out.WriteLine(niceCount);


            Console.In.Read();
        }

        /*static public bool isNice(string input)
        {
            bool contitions = false;
            
            Regex regex = new Regex("(.)\\1");
            Match match = regex.Match(input);
            if (match.Success)
            {
                //Console.Out.Write(match.Value + ": ");
                contitions = true;
            }

            regex = new Regex(@"[aeiou]");
            int matches = regex.Matches(input).Count;
            if (matches < 3)
            {
                contitions = false;
            }
            //Console.Out.Write(matches + ": ");


            regex = new Regex("ab|cd|pq|xy");
            match = regex.Match(input);
            if (match.Success)
            {
                //Console.Out.Write(match.Value + ": ");
                contitions = false;
            }

            return contitions;
        }*/

        public static bool isNice(string input)
        {
            bool contitions1 = false;
            bool contitions2 = false;
            Regex regex;

            Char lastChar = 'a';
            foreach (char c in input)
            {
                regex = new Regex(lastChar.ToString() + c);
                MatchCollection matches = regex.Matches(input);
                if (matches.Count > 1)
                {
                    foreach (Match match1 in matches)
                    {
                        //Console.Out.WriteLine(match1 + ": ");
                        contitions1 = true;
                    }
                }
                lastChar = c;
            }

            regex = new Regex("(?=.).");
            Match match = regex.Match(input);
            foreach (char c in input)
            {
                regex = new Regex(c + "." + c);
                match = regex.Match(input);
                if (match.Success)
                {
                    //Console.Out.Write(match.Value + ": ");
                    contitions2 = true;
                }
            }
            return contitions1 && contitions2;
        }
    }
}

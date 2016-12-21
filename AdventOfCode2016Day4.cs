using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApplication1
{
    using System.Text;

    class AdventOfCode2016Day4
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

        static void Code2016Day4(string[] args)
        {
            //var uri = new System.Uri(@"http://adventofcode.com/2016/day/4/input");
            //var webClient = new WebClient();
            //String text = webClient.DownloadString(uri);

            String text = File.ReadAllText(@"C:\Users\Z236\Documents\adventofcode\Day4input.txt");
            //String text = File.ReadAllText(@"C:\Users\Z236\Documents\adventofcode\Day4test.txt");
            string[] instructions = text.Split('\n');
            int total = 0;
            foreach (string instruction in instructions)
            {
                total += Checksum(instruction);
            }
            Console.Out.WriteLine(total);

            string output = "";
            StreamWriter file = new StreamWriter("decryptedtext.txt");
            foreach (string instruction in instructions)
            {
                output += Decrypt(instruction);
                //Console.WriteLine(Decrypt(instruction));
            }
            file.WriteLine(output);
            file.Close();
            //Console.Out.WriteLine(total);
            Console.In.Read();
        }

        private static int Checksum(string instruction)
        {
            string encrypted = instruction.Split('[')[0];
            string check = instruction.Substring(instruction.IndexOf('[') + 1, 5);
            int sum = Convert.ToInt32(encrypted.Split('-').Last());
            List<Frequancy> f = new List<Frequancy>();

            int[] c = new int[(int)char.MaxValue];
            foreach (char t in encrypted)
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

            //Console.WriteLine(result.ToString().Substring(0, check.Length));
            if (!result.ToString().Substring(0, check.Length).Equals(check))
            {
                sum = 0;
            }

            /*
            foreach (char c in check)
            {
                var count = encrypted.Count(x => x == c);
                Console.Out.Write(c + ":" + count + " ");
                
                if (count == 0)
                {
                    sum = 0;
                }

            }
            Console.Out.WriteLine();*/

            return sum;
        }

        private static string Decrypt(string instruction)
        {
            string encrypted = instruction.Split('[')[0];
            string check = instruction.Substring(instruction.IndexOf('[') + 1, 5);

            string output = "";
            int shift = Convert.ToInt32(encrypted.Split('-').Last()) % 26;
            string cipher = encrypted.Substring(0, encrypted.Length-4);

            char[] decr = cipher.ToCharArray();

            for (int i = 0; i < decr.Length; i++)
            {

                {
                    char character = decr[i];
                    if (character != '-')
                    {
                        character = (char)(character + shift);
                    }
                    else
                    {
                        character = '\t';
                    }

                    if (character == '-' || character == ' ')
                    {
                        continue;
                    }

                    if (character > 'z')
                        character = (char)(character - 26);

                    else if (character < 'a')
                        character = (char)(character + 26);


                    output = output + character;
                }

                //Console.WriteLine("\nShift {0} \n {1}", i + 1, output);
            }
            output += " " + encrypted.Split('-').Last();
            output = output.Replace('#', ' ');
            output += '\n';
            return output;
        }
    }
}

namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Linq;
    using System.Text;

    public class AdventOfCode2015Day4
    {
        static void Code2015Day4(string[] args)
        {

            //var uri = new System.Uri(@"http://adventofcode.com/2015/day/4/input");
            //var webClient = new WebClient();
            //String text = webClient.DownloadString(uri);

            //String secret = "abcdef";
            //String secret = "pqrstuv";
            String secret = "bgvyzdsv";

            /*String firstfive = CalculateMD5Hash(secret.ToString()).Substring(0, 5);
            for (int i = 0; i < Int32.MaxValue; i++ )
            {
                firstfive = CalculateMD5Hash(secret + i.ToString()).Substring(0, 5);
                if (firstfive == "00000")
                {
                    Console.Out.WriteLine(i);
                    Console.Out.WriteLine(firstfive);
                    break;
                }
            }*/

            String firstsix = CalculateMD5Hash(secret.ToString()).Substring(0, 6);
            for (int i = 0; i < Int32.MaxValue; i++)
            {
                firstsix = CalculateMD5Hash(secret + i.ToString()).Substring(0, 6);
                if (firstsix == "000000")
                {
                    Console.Out.WriteLine(i);
                    Console.Out.WriteLine(firstsix);
                    break;
                }
            }

            Console.In.Read();
        }

        static public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}

namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Linq;
    using System.Text;

    public class AdventOfCode2016Day5
    {
        static void Code2016Day5(string[] args)
        {
            //String secret = "abc";
            String secret = "uqwqemis";

            
            int x = 0;
            String firstfive = CalculateMD5Hash(secret.ToString()).Substring(0, 5);
            for (int i = 0; x < 8; i++ )
            {
                String firstsix = CalculateMD5Hash(secret + i.ToString()).Substring(0, 6);
                firstfive = firstsix.Substring(0, 5);
                if (firstfive == "00000")
                {
                    Console.Out.Write(firstsix.Substring(5,1));
                    x++;
                }
            }

            
            StringBuilder password = new StringBuilder(new string(' ', 8));
            firstfive = "";
            for (int i = 0; i < Int32.MaxValue; i++ )
            {
                string firstseven = CalculateMD5Hash(secret + i.ToString()).Substring(0, 7);
                firstfive = firstseven.Substring(0, 5);
                if (firstfive == "00000")
                {
                    switch (firstseven.ToCharArray()[5])
                    {
                        case '0':
                            if (password[0] == ' ')
                            {
                                password[0] = firstseven.ToCharArray()[6];
                            }
                            Console.Out.WriteLine(password.ToString());
                            break;
                        case '1':
                            if (password[1] == ' ')
                            {
                                password[1] = firstseven.ToCharArray()[6];
                            }
                            Console.Out.WriteLine(password.ToString());
                            break;
                        case '2':
                            if (password[2] == ' ')
                            {
                                password[2] = firstseven.ToCharArray()[6];
                            }
                            Console.Out.WriteLine(password.ToString());
                            break;
                        case '3':
                            if (password[3] == ' ')
                            {
                                password[3] = firstseven.ToCharArray()[6];
                            }
                            Console.Out.WriteLine(password.ToString());
                            break;
                        case '4':
                            if (password[4] == ' ')
                            {
                                password[4] = firstseven.ToCharArray()[6];
                            }
                            Console.Out.WriteLine(password.ToString());
                            break;
                        case '5':
                            if (password[5] == ' ')
                            {
                                password[5] = firstseven.ToCharArray()[6];
                            }
                            Console.Out.WriteLine(password.ToString());
                            break;
                        case '6':
                            if (password[6] == ' ')
                            {
                                password[6] = firstseven.ToCharArray()[6];
                            }
                            Console.Out.WriteLine(password.ToString());
                            break;
                        case '7':
                            if (password[7] == ' ')
                            {
                                password[7] = firstseven.ToCharArray()[6];
                            }
                            Console.Out.WriteLine(password.ToString());
                            break;
                    }

                    if (!password.ToString().Contains(' '))
                    {
                        Console.Out.WriteLine("\nFinished");
                        break;
                    }
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
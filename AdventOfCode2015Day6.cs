using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    class AdventOfCode2015Day6
    {
        public class Light
        {
            public int X, Y;
            public bool lit;

            public Light()
            {
                this.X = 0;
                this.Y = 0;
                this.lit = false;
            }

            public Light(int xIn, int yIn, bool lit)
            {
                this.X = xIn;
                this.Y = yIn;
                this.lit = lit;
            }

            public override string ToString()
            {
                return "X:" + X.ToString() + " Y:" + Y.ToString() + "On: "+ lit;
            }

            public bool Toggle()
            {
                this.lit = !lit;
                return lit;
            }
            public bool On()
            {
                this.lit = true;
                return lit;
            }
            public bool Off()
            {
                this.lit = false;
                return lit;
            }
        }

        static void Main(string[] args)
        {
            List<Light> lights = new List<Light>();
            int index = 0;

            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    lights.Add(new Light(x,y,false));
                }
            }

            //var uri = new System.Uri(@"http://adventofcode.com/2015/day/6/input");
            //var webClient = new WebClient();
            //String text = webClient.DownloadString(uri);

            String text = File.ReadAllText(@"C:\Users\Z236\Documents\adventofcode\2015Day6input.txt");
            //string text = File.ReadAllText(@"C:\Users\Z236\Documents\adventofcode\Day1test.txt");
            string[] instructions = text.Split('\n');

            foreach (var instruction in instructions)
            {
                Console.WriteLine(instruction);
                
                /*
                switch (instruction[0])
                {
                    case "on":
                        for (index = instruction[1]; index < instruction[2]; index++)
                        {
                            lights.ElementAt(index).On();
                        }
                        break;
                    case "off":
                        for (index = instruction[1]; index < instruction[2]; index++)
                        {
                            lights.ElementAt(index).Off();
                        }
                        break;
                    case "toggle":
                        for (index = instruction[1]; index < instruction[2]; index++)
                        {
                            lights.ElementAt(index).Toggle();
                        }
                        break;
                }*/
            }

            Console.In.Read();
        }

    }
}

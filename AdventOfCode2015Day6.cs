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

<<<<<<< HEAD
        static void Code2015Day6(string[] args)
=======
        public class BrightLight
>>>>>>> ef1ed61a52eb0900342607045ed585daa93722b7
        {
            public int X, Y;
            public int brightness;

            public BrightLight()
            {
                this.X = 0;
                this.Y = 0;
                this.brightness = 1;
            }

            public BrightLight(int xIn, int yIn, int brightness)
            {
                this.X = xIn;
                this.Y = yIn;
                this.brightness = brightness;
            }

            public override string ToString()
            {
                return "X:" + X.ToString() + " Y:" + Y.ToString() + "On: " + brightness;
            }

            public int Toggle()
            {
                this.brightness += 2;
                return brightness;
            }
            public int On()
            {
                this.brightness += 1;
                return brightness;
            }
            public int Off()
            {
                this.brightness -= 1;
                if (brightness < 0)
                {
                    brightness = 0;
                }
                return brightness;
            }
        }

        static void Code2015Day6(string[] args)
        {
            Light[,] lights = new Light[1000, 1000];
            for (int y = 0; y < 1000; y++)
            {
                for (int x = 0; x < 1000; x++)
                {
                    lights[x, y] = new Light(x,y,false);
                }
            }

            BrightLight[,] bright = new BrightLight[1000, 1000];
            for (int y = 0; y < 1000; y++)
            {
                for (int x = 0; x < 1000; x++)
                {
                    bright[x, y] = new BrightLight(x, y, 0);
                }
            }
            int totalbrightness = 0;

            //var uri = new System.Uri(@"http://adventofcode.com/2015/day/6/input");
            //var webClient = new WebClient();
            //String text = webClient.DownloadString(uri);

            String text = File.ReadAllText(@"C:\Users\Z236\Documents\adventofcode\2015Day6input.txt");
            //string text = File.ReadAllText(@"C:\Users\Z236\Documents\adventofcode\2015Day6test.txt");
            string[] instructions = text.Split('\n');

            foreach (var instruction in instructions)
            {
                Console.WriteLine(instruction);
                int startx  = Convert.ToInt32(instruction.Split(' ')[1].Split(',')[0]);
                int starty  = Convert.ToInt32(instruction.Split(' ')[1].Split(',')[1]);
                int endx    = Convert.ToInt32(instruction.Split(' ')[2].Split(',')[0]);
                int endy    = Convert.ToInt32(instruction.Split(' ')[2].Split(',')[1]);
                
                if (instruction.Split(' ')[0] == "on")
                {
                    for (int y = starty; y < endy + 1; y++)
                    {
                        for (int x = startx; x < endx + 1; x++)
                        {
                            lights[x, y].On();
                            bright[x, y].On();
                        }
                    }
                }
                else if (instruction.Split(' ')[0] == "off")
                {
                    for (int y = starty; y < endy + 1; y++)
                    {
                        for (int x = startx; x < endx + 1; x++)
                        {
                            lights[x, y].Off();
                            bright[x, y].Off();
                        }
                    }
                }
                else if (instruction.Split(' ')[0] == "toggle")
                {
                    for (int y = starty; y < endy + 1; y++)
                    {
                        for (int x = startx; x < endx + 1; x++)
                        {
                            lights[x, y].Toggle();
                            bright[x, y].Toggle();
                        }
                    }
                }
            }

            int total = 0;
            foreach (Light light in lights)
            {
                if (light.lit)
                {
                    total++;
                }
            }
            Console.Out.WriteLine(total);

            foreach (BrightLight b in bright)
            {
                totalbrightness += b.brightness;
            }
            Console.Out.WriteLine(totalbrightness);
            Console.In.Read();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAC2022.Day_1
{
    public class Day8 : Day<int>
    {
        override public int TestValue1
        {
            get
            {
                return 21;
            }
        }
        override public int TestValue2
        {
            get
            {
                return 8;
            }
        }

        bool isVisible(int[,] arr, int x, int y)
        {
            bool visible = false;
            int tree = arr[x, y];
            int hits = 0;

            for (int dir = 0; dir <= 3; dir++)
            {
                int accessorX = x, accessorY = y;
                

                while (accessorX < (arr.GetLength(0) - 1) && accessorY < (arr.GetLength(1) - 1) && accessorX * accessorY != 0)
                {
                    switch(dir)
                    {
                        case 0:
                            // GO UP
                            accessorY -= 1;
                            break;
                        case 1:
                            // GO DOWN
                            accessorY += 1;
                            break;
                        case 2:
                            // GO RIGHT
                            accessorX += 1;
                            break;
                        case 3:
                            // GO LEFT
                            accessorX -= 1;
                            break;
                    }

                    Console.WriteLine($"x: {accessorX} y: {accessorY}");
                    int pnt = arr[accessorX, accessorY];
                    if (pnt >= tree)
                    {
                        hits += 1;
                        break;
                    };
                }


            }

            if (hits != 4) visible = true;
            Console.WriteLine($"Hits: {hits} | {visible}");

            return visible;
        }

        int getScenicScore(int[,] arr, int x, int y)
        {
            int tree = arr[x, y];
            int score = 1;

            for (int dir = 0; dir <= 3; dir++)
            {
                int accessorX = x, accessorY = y;


                while (accessorX < (arr.GetLength(0) - 1) && accessorY < (arr.GetLength(1) - 1) && accessorX * accessorY != 0)
                {
                    switch (dir)
                    {
                        case 0:
                            // GO UP
                            accessorY -= 1;
                            break;
                        case 1:
                            // GO DOWN
                            accessorY += 1;
                            break;
                        case 2:
                            // GO RIGHT
                            accessorX += 1;
                            break;
                        case 3:
                            // GO LEFT
                            accessorX -= 1;
                            break;
                    }

                    Console.WriteLine($"x: {accessorX} y: {accessorY}");
                    int pnt = arr[accessorX, accessorY];
                    if (pnt >= tree) break;
                }

                score *= Math.Abs(x - accessorX) + Math.Abs(y - accessorY);


            }

            Console.WriteLine($"score: {score}");

            return score;
        }

        int[,] getForrest(string[] input)
        {
            int width = input[0].Length, height = input.Length;
            int[,] forrest = new int[width, height];

            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    var e = input[h][w];
                    forrest[h, w] = e - '0';
                }
            }

            return forrest;
        }

        override public int Challange1(string[] input)
        {
            int width = input[0].Length, height = input.Length;
            int[,] forrest = getForrest(input);

            int tally = (width * 2) + ((height - 2) * 2);

            Console.WriteLine("TALLY: " + tally);

            for (int w = 1; w < width - 1; w++)
            {
                for(int h = 1; h < height - 1; h++)
                {
                    if (isVisible(forrest, h, w)) tally++;
                }
            }

            // 1870 was correct but this solution could be improved by a LOT.
            // A win is a win so ill gladly take it tho

            return tally;
        }

        override public int Challange2(string[] input)
        {
            int width = input[0].Length, height = input.Length;
            int[,] forrest = getForrest(input);

            int tally = (width * 2) + ((height - 2) * 2);

            Console.WriteLine("TALLY: " + tally);

            int max = 0;

            for (int w = 1; w < width - 1; w++)
            {
                for (int h = 1; h < height - 1; h++)
                {
                    int score = getScenicScore(forrest, h, w);
                    if (score > max) max = score;
                }
            }

            // 517440 was correct!
            // This challange was not really my forte. I like the silly little challanges where I need to parse data
            // like the previous one. Just crunching numbers is not something I find too enjoyable.


            return max;
        }
    }
}

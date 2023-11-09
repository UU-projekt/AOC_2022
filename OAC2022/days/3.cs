using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAC2022.Day_1
{
    public class Day3 : Day<int>
    {
        override public int TestValue1
        {
            get
            {
                return 157;
            }
        }
        override public int TestValue2
        {
            get
            {
                return 70;
            }
        }

        int GetPriorityScore(char c)
        {
            if(Helpers.Within('a', 'z', c))
            {
                return c - 'a' + 1;
            } else
            {
                return c - 'A' + 27;
            }
        }

        override public int Challange1(string[] input)
        {
            int score = 0;
            foreach(var bag in input)
            {
                if (String.IsNullOrEmpty(bag)) continue;
                string p2 = bag.Substring(bag.Length / 2);
                string p1 = bag.Substring(0, bag.Length / 2);

                foreach(char c1 in p1)
                {
                    int s = -1;
                    foreach(char c2 in p2)
                    {
                        if(c1 == c2)
                        {
                            Console.WriteLine($"FOUND '{c1}' ({GetPriorityScore(c1)}) in {bag}");
                            s = GetPriorityScore(c1);
                            break;
                        }
                    }

                    if(s != -1)
                    {
                        score += s;
                        break;
                    }
                }
            }

            return score;
        }

        override public int Challange2(string[] input)
        {
            int tot = 0;
            string[] group = new string[3];
            bool[,] chars = new bool[3, 52];

            for(int i = 0; i < input.Length; i++)
            {
                int memberNr = i % 3;
                string bag = input[i];
                group[memberNr] = bag;

                foreach(char c in bag)
                {
                    chars[memberNr, GetPriorityScore(c) - 1] = true;
                }

                if(memberNr == 2)
                {
;
                    Helpers.PrettyPrint(group, true);
                    for(int j = 0; j < 52; j++)
                    {
                        if (chars[0, j] && chars[1, j] && chars[2, j])
                        {
                            tot += j + 1;
                            break;
                        }
                    }
                    chars = new bool[3, 52];
                }
            }
            return tot;
        }
    }
}

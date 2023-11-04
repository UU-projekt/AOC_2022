using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAC2022.Day_1
{
    public class Day1 : Day
    {
        override public int TestValue1
        {
            get
            {
                return 24000;
            }
        }
        override public int TestValue2
        {
            get
            {
                return 45000;
            }
        }
        override public int Challange1(string[] input)
        {
            int max = 0;
            int currTally = 0;
            foreach (var item in input)
            {
                if (String.IsNullOrEmpty(item))
                {
                    if (currTally > max) { max = currTally; }
                    currTally = 0;
                }
                else
                {
                    currTally += int.Parse(item);
                }
            }

            return max;
        }

        override public int Challange2(string[] input)
        {
            int[] highest = new int[3];
            int tally = 0;

            foreach(string elf in input)
            {
                if(String.IsNullOrEmpty(elf))
                {
                    for (int i = highest.Length - 1; i >= 0; i--)
                    {
                        if(tally > highest[i])
                        {
                            // move arr down
                            for(int j = 0; j < i; j++)
                            {
                                highest[j] = highest[j + 1];
                            }
                            highest[i] = tally;
                            break;
                        }
                    }
                    tally = 0;
                } else
                {
                    tally += int.Parse(elf);
                }
            }

            return highest[0] + highest[1] + highest[2];
        }
    }
}

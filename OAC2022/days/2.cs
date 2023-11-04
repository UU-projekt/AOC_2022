using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAC2022.Day_1
{
    public class Day2 : Day
    {
        override public int TestValue1
        {
            get
            {
                return 15;
            }
        }
        override public int TestValue2
        {
            get
            {
                return 12;
            }
        }
        override public int Challange1(string[] input)
        {
            // a/x: rock    1
            // b/y: paper   2
            // c/z: scissor 3
            // lost: 0 draw: 3 won: 6

            int totalScore = 0;

            foreach (var round in input)
            {
                if (String.IsNullOrEmpty(round)) continue;
                string[] r = round.Split(' ');
                // Turn the characters into the int representation of the draw instead
                int foe =  (r[0][0] - 'A'), you = (r[1][0] - 'X');

                int roundScore = you + 1;

                if(you == (foe + 1) % 3)
                {
                    roundScore += 6;
                } else if(you == foe)
                {
                    roundScore += 3;
                }
                totalScore += roundScore;
            }

            // 12231 (too low)
            // 12645 (correct)
            return totalScore;
        }

        override public int Challange2(string[] input)
        {
            // a: rock    1
            // b: paper   2
            // c: scissor 3
            // x: lost
            // y: draw
            // z: win
            // lost: 0 draw: 3 won: 6

            int totalScore = 0;

            foreach (var round in input)
            {
                if (String.IsNullOrEmpty(round)) continue;
                string[] r = round.Split(' ');
                // Turn the characters into the int representation of the draw instead
                int foe = (r[0][0] - 'A'), you = (r[1][0] - 'X');

                switch(you)
                {
                    case 0:
                        if (foe == 0) you = 2;
                        else you = foe - 1;
                        break;
                    case 1:
                        you = foe;
                        break;
                    case 2:
                        you = (foe + 1) % 3;
                        break;
                }

                int roundScore = you + 1;

                if (you == (foe + 1) % 3)
                {
                    roundScore += 6;
                }
                else if (you == foe)
                {
                    roundScore += 3;
                }
                totalScore += roundScore;
            }

            // 10157 (too low)
            // 11756 (correct)
            return totalScore;
        }
    }
}

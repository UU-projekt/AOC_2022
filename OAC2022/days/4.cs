using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAC2022.Day_1
{
    public class Day4 : Day
    {
        override public int TestValue1
        {
            get
            {
                return 2;
            }
        }
        override public int TestValue2
        {
            get
            {
                return 4;
            }
        }

        class Range
        {
            public int a;
            public int b;
            public Range(int _a, int _b)
            {
                a = _a;
                b = _b;
            }

            public static Range from(string s)
            {
                string[] r = s.Split('-');
                int a = int.Parse(r[0]), b = int.Parse(r[1]);
                if(a > b)
                {
                    var temp = b;
                    b = a;
                    a = temp;
                }

                return new Range(a, b);
            }

            public bool Contains(Range b)
            {
                Console.WriteLine($"{this.a}-{this.b} : {b.a}-{b.b}");
                Console.WriteLine(b.b <= this.b && b.a >= this.a);
                return (b.b <= this.b && b.a >= this.a);
            }

            public bool Overlaps(Range b)
            {
                if (this.Contains(b) || b.Contains(this)) return true;

                Console.WriteLine($"{this.a}-{this.b} : {b.a}-{b.b}");
                Console.WriteLine(Helpers.Within(b.a, b.b, this.a) || Helpers.Within(b.a, b.b, this.b));
                return (Helpers.Within(b.a, b.b, this.a) || Helpers.Within(b.a, b.b, this.b));
            }

            public int Length
            {
                get
                {
                    return this.b - this.a;
                }
            }
        }

        override public int Challange1(string[] input)
        {
            int contains = 0;

            foreach (string s in input)
            {
                if (String.IsNullOrEmpty(s)) continue;

                string[] r = s.Split(',');
                Range elf1 = Range.from(r[0]), elf2 = Range.from(r[1]);

                if(elf1.Length < elf2.Length)
                {
                    var temp = elf2;
                    elf2 = elf1;
                    elf1 = temp;
                }

                if(elf1.Contains(elf2))
                {
                    contains++;
                }

            }
            
            return contains;
        }

        override public int Challange2(string[] input)
        {
            int contains = 0;

            foreach (string s in input)
            {
                if (String.IsNullOrEmpty(s)) continue;

                string[] r = s.Split(',');
                Range elf1 = Range.from(r[0]), elf2 = Range.from(r[1]);

                if (elf1.Length < elf2.Length)
                {
                    var temp = elf2;
                    elf2 = elf1;
                    elf1 = temp;
                }

                if (elf1.Overlaps(elf2))
                {
                    contains++;
                }

            }

            return contains;
        }
    }
}

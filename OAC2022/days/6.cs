using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAC2022.Day_1
{
    public class Day6 : Day<int>
    {
        override public int TestValue1
        {
            get
            {
                return 7;
            }
        }
        override public int TestValue2
        {
            get
            {
                return 19;
            }
        }

        static bool AllUnique(char[] chars)
        {
            int cursor = 0;
            while (cursor < chars.Length - 1)
            {
                char c = chars[cursor];
                for (int i = cursor + 1; i < chars.Length; i++) {
                    if (c == chars[i])
                    {
                        return false;
                    }
                }
                cursor++;
            }

            return true;
        }

        class FixedArray
        {
            private char[] array;

            public int Length {
                get => array.Length;
            }

            public int ActualLength
            {
                get
                {
                    int res = 0;
                    foreach (char c in array)
                    {
                        if (c != default(char)) res++;
                    }

                    return res;
                }
            }

            public FixedArray(int size)
            {
                array = new char[size];
            }

            public void Add(char item)
            {
                for (int i = array.Length - 1; i >= 1; i--)
                {
                    array[i] = array[i - 1];
                }
                array[0] = item;
            }

            public char[] GetArray()
                => this.array;
        }

        override public int Challange1(string[] input)
        {
            string dataBuffer = input[0];
            FixedArray charArr = new FixedArray(4);

            for (int i = 0; i < dataBuffer.Length; i++)
            {
                charArr.Add(dataBuffer[i]);

                if (charArr.ActualLength == 4 && AllUnique(charArr.GetArray()))
                {
                    return i + 1;
                }
            }

            // 1794
            return -1;
        }

        override public int Challange2(string[] input) {
            string dataBuffer = input[0];
            FixedArray charArr = new FixedArray(14);

            for (int i = 0; i < dataBuffer.Length; i++)
            {
                charArr.Add(dataBuffer[i]);

                if (charArr.ActualLength == 14 && AllUnique(charArr.GetArray()))
                {
                    return i + 1;
                }
            }

            // 2851
            return -1;
        }
    }
}

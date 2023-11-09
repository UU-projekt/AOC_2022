using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAC2022.Day_1
{
    public class Day5 : Day<string>
    {
        override public string TestValue1
        {
            get
            {
                return "CMZ";
            }
        }
        override public string TestValue2
        {
            get
            {
                return "MCD";
            }
        }
        override public string Challange1(string[] input)
        {
            bool readingHeader = true;
            List<char>[] stacks = new List<char>[0];

            foreach(var item in input)
            {
                if(String.IsNullOrEmpty(item))
                {
                    readingHeader = false;
                    continue;
                }

                if(readingHeader)
                {

                    if (stacks.Length == 0)
                    {
                        stacks = new List<char>[((item.Length - 1) / 4) + 1];
                        for(int i = 0; i < stacks.Length; i++)
                        {
                            stacks[i] = new List<char>();
                        }
                    }

                    for (int i = 1; i < item.Length; i += 4)
                    {
                        char c = item[i];
                        int trueIndex = i / 4;

                        Console.Write(c + $"({trueIndex}) ");
                        if (char.IsNumber(c) || !char.IsLetter(c)) continue;
                        stacks[trueIndex].Add(c);
                    }
                    Console.WriteLine();
                    continue;
                }

                int[] parameters = new int[3];

                int bufC = 0;
                foreach(string chunk in item.Split(' '))
                {
                    bool succeeded = int.TryParse(chunk, out int parsed);
                    if(succeeded)
                    {
                        parameters[bufC] = parsed;
                        bufC += 1;
                    }
                }

                int amount = parameters[0], from = parameters[1], to = parameters[2];

                for (int i = 0; i < amount; i++)
                {
                    Console.WriteLine($"to: {to - 1} from: {from - 1}");
                    stacks[to - 1].Insert(0, stacks[from - 1][0]);
                    stacks[from - 1].RemoveAt(0);
                }

                Console.WriteLine($"move {amount} from {from} to {to}");

            }
            string answer = "";
            foreach(var stack in stacks)
            {
                answer += stack[0];
            }

            Console.WriteLine(answer);
            return answer;
        }

        override public string Challange2(string[] input)
        {
            bool readingHeader = true;
            List<char>[] stacks = new List<char>[0];

            foreach (var item in input)
            {
                if (String.IsNullOrEmpty(item))
                {
                    readingHeader = false;
                    continue;
                }

                if (readingHeader)
                {

                    if (stacks.Length == 0)
                    {
                        stacks = new List<char>[((item.Length - 1) / 4) + 1];
                        for (int i = 0; i < stacks.Length; i++)
                        {
                            stacks[i] = new List<char>();
                        }
                    }

                    for (int i = 1; i < item.Length; i += 4)
                    {
                        char c = item[i];
                        int trueIndex = i / 4;

                        Console.Write(c + $"({trueIndex}) ");
                        if (char.IsNumber(c) || !char.IsLetter(c)) continue;
                        stacks[trueIndex].Add(c);
                    }
                    Console.WriteLine();
                    continue;
                }

                int[] parameters = new int[3];

                int bufC = 0;
                foreach (string chunk in item.Split(' '))
                {
                    bool succeeded = int.TryParse(chunk, out int parsed);
                    if (succeeded)
                    {
                        parameters[bufC] = parsed;
                        bufC += 1;
                    }
                }

                int amount = parameters[0], from = parameters[1], to = parameters[2];

                List<char> stack = new List<char>();

                for (int i = 0; i < amount; i++)
                {
                    Console.WriteLine($"to: {to - 1} from: {from - 1}");
                    stack.Add(stacks[from - 1][0]);
                    stacks[from - 1].RemoveAt(0);
                }

                stacks[to - 1].InsertRange(0, stack);

                Console.WriteLine($"move {amount} from {from} to {to}");

            }
            string answer = "";
            foreach (var stack in stacks)
            {
                answer += stack[0];
            }

            // "FWNSHLDNZ" WRONG
            return answer;
        }
    }
}

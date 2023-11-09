using OAC2022.Day_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAC2022
{
    public class Helpers
    {
        static string INPUTS_DIR = "C:\\Users\\jonat\\OneDrive\\Gammalt\\Documents\\AOC\\2022";
        public static string[] ReadInput(int day, bool real = true)
        {
            using(var sr = new StreamReader(Path.Join(INPUTS_DIR, $"day_{(real ? "" : "test_")}{day}.txt")))
            {
                List<string> result = new List<string>();

                while(!sr.EndOfStream) {
                    result.Add(sr.ReadLine()??"<NULL>");
                }

                return result.ToArray();
            }
        }

        public static bool Assert<T>(T certain, T result) where T : IEquatable<T>
        {
            bool equal = certain.Equals(result);

            Console.Write("[");
            if (equal) Console.ForegroundColor = ConsoleColor.Green;
            else Console.ForegroundColor = ConsoleColor.Red;

            Console.Write(equal ? "OK" : "FAIL");

            Console.ResetColor();

            Console.Write("] ");

            Console.WriteLine($"Assert {certain} = {result}");

            Console.ResetColor();

            return equal;
        }

        public static void PrettyPrint<T>(T[] arr, bool newLines = false)
        {
            Console.Write(nameof(arr) + ": " + (newLines ? "\n" : ""));
            for(int i = 0; i < arr.Length; i++)
            {
                if (newLines) Console.Write("- ");
                Console.Write(arr[i]);
                if(i != arr.Length - 1)
                {
                    if (newLines) Console.WriteLine();
                    else Console.Write(", ");
                }
            }
            Console.WriteLine();
        }

        public static bool Within(int a, int b, int val)
        {
            if (val < a || b < val) return false;
            return true;
        }

        public class MutedConsole : IDisposable
        {
            private TextWriter _writerOut;
            private TextWriter _writerErr;

            public MutedConsole()
            {
                _writerOut = Console.Out;
                _writerErr = Console.Error;
                Console.SetOut(TextWriter.Null);
                Console.SetError(TextWriter.Null);
            }

            public static MutedConsole Get()
            {
                return new MutedConsole();
            }

            public virtual void Dispose()
            {
                Console.SetOut(_writerOut);
                Console.SetError(_writerErr);
            }
        }

        static IDaySolve[] Solutions =
        {
            new Day1() { ChallangeDay = 1 },
            new Day2() { ChallangeDay = 2 },
            new Day3() { ChallangeDay = 3 },
            new Day4() { ChallangeDay = 4 },
            new Day5() { ChallangeDay = 5 },
            new Day6() { ChallangeDay = 6 },
        };

        public static void RunChallange(int day)
        {
            IDaySolve code = Solutions[day - 1];
            
            for(int i = 1; i <= 2; i++)
            {
                Console.WriteLine($"Challange {i}:");
                code.AssertTest(i);
                var val = code.Run(i);
                Console.WriteLine($"value: {val}");
            }

        }
    }
}

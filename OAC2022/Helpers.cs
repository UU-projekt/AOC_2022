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

        public static void Assert<T>(T certain, T result) where T : IEquatable<T>
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

        static Day[] Solutions =
        {
            new Day1(),
            new Day2(),
            new Day3(),
            new Day4()
        };

        public static void RunChallange(int day)
        {
            Day code = Solutions[day - 1];
            string[] testData = Helpers.ReadInput(day, false);

            string[] realData = Helpers.ReadInput(day, true);

            Console.WriteLine($"Advent Of Code day {day}");

            Console.WriteLine("Challange 1");
            Helpers.Assert(code.TestValue1, code.Challange1(testData));

            int res1 = 0;
            using(MutedConsole.Get())
            {
                res1 = code.Challange1(realData);
            }

            Console.WriteLine($"value: {res1}");

            Console.WriteLine("\nChallange 2");
            Helpers.Assert(code.TestValue2, code.Challange2(testData));

            int res2 = 0;
            using(MutedConsole.Get())
            {
                res2 = code.Challange2(realData);
            }

            Console.WriteLine($"value: {res2}");

        }
    }
}

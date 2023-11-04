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

        public static void RunChallange(int day, Day code)
        {
            string[] testData = Helpers.ReadInput(day, false);

            string[] realData = Helpers.ReadInput(day, true);

            Console.WriteLine($"Advent Of Code day {day}");

            Console.WriteLine("Challange 1");
            Helpers.Assert(code.TestValue1, code.Challange1(testData));
            Console.WriteLine($"value: {code.Challange1(realData)}");

            Console.WriteLine("\nChallange 2");
            Helpers.Assert(code.TestValue2, code.Challange2(testData));
            Console.WriteLine($"value: {code.Challange2(realData)}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAC2022
{
    public interface IDaySolve
    {
        public int ChallangeDay { get; init; }
        public bool AssertTest(int test);
        public string? Run(int challange);
    }
    public abstract class Day<T> : IDaySolve where T : IEquatable<T>
    {
        public int ChallangeDay { get; init; }
        public abstract T TestValue1 { get; }
        public abstract T TestValue2 { get; }
        public abstract T Challange1(string[] input);
        public abstract T Challange2(string[] input);

        public bool AssertTest(int challange)
        {
            string[] testData = Helpers.ReadInput(ChallangeDay, false);
            bool res = false;

            if (challange == 1) res = Helpers.Assert(this.TestValue1, this.Challange1(testData));
            else res = Helpers.Assert(this.TestValue2, this.Challange2(testData));

            return res;
        }

        public string? Run(int challange)
        {
            string[] realData = Helpers.ReadInput(ChallangeDay, true);
            using(Helpers.MutedConsole.Get())
            {
                if (challange == 1)
                {
                    return this.Challange1(realData).ToString();
                }
                else
                {
                    return this.Challange2(realData).ToString();
                }
            }
        }
    }
}

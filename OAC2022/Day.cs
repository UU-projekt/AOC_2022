using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAC2022
{
    public abstract class Day
    {
        public abstract int TestValue1 { get; }
        public abstract int TestValue2 { get; }
        public abstract int Challange1(string[] input);
        public abstract int Challange2(string[] input);
    }
}

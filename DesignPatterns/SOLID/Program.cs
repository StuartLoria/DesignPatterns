using SOLID.Principles;
using System;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSingleResponsibility();
        }

        private static void TestSingleResponsibility()
        {
            SingleResponsibility principle = new SingleResponsibility();
            principle.Test();
        }
    }
}

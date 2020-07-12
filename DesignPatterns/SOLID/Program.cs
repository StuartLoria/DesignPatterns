using SOLID.Principles;
using System;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSingleResponsibility();

            System.Console.WriteLine("Press any key to finish...");
            System.Console.ReadLine();
        }

        private static void TestSingleResponsibility()
        {
            SingleResponsibility principle = new SingleResponsibility();
            principle.Test();
        }

        private static void TestOpenClose()
        {
            OpenClose principle = new OpenClose();
            principle.Test();
        }
    }
}

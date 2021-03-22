using MultiThread;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiThread();
            Console.ReadKey();
        }

        static void MultiThread()
        {
            var foo = new MultiPractice();
            foo.Demo1();
        }
    }
}

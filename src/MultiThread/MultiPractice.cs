using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultiThread
{
    public class MultiPractice
    {
        private int _count1;

        public void Demo1()
        {
            var tasks = new Task[10];
            for (var i = 0; i < 10; i++)
            {
                tasks[i] = new Task(Count1);
            }

            Task.WhenAll(tasks);
            Console.WriteLine($"the current count is: {_count1}");
        }

        private void Count1()
        {
            for (var j = 0; j < 1000; j++)
            {
                _count1++;
            }
        }
    }
}

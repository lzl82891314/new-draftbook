using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace MultiThread
{
    public class MultiPractice
    {
        private int _count1;
        private int _count2;
        private readonly object _lock = new object();
        private const int N = 100000;
        private const int M = 10;

        public void Demo1()
        {
            _count1 = 0;
            var watcher = Stopwatch.StartNew();
            var tasks = new Task[M];
            for (var i = 0; i < M; i++)
            {
                tasks[i] = Task.Factory.StartNew(Count1);
            }

            Task.WaitAll(tasks);
            watcher.Stop();
            Console.WriteLine($"the {nameof(_count1)} is: {_count1}, totally spent [{watcher.ElapsedMilliseconds}]ms");
        }

        public void Demo2()
        {
            _count2 = 0;
            var watcher = Stopwatch.StartNew();
            var tasks = new Task[M];
            for (var i = 0; i < M; i++)
            {
                tasks[i] = Task.Factory.StartNew(Count2);
            }

            Task.WaitAll(tasks);
            watcher.Stop();
            Console.WriteLine($"the {nameof(_count2)} is: {_count2}, totally spent [{watcher.ElapsedMilliseconds}]ms");
        }

        private void Count1()
        {
            for (var j = 0; j < N; j++)
            {
                _count1++;
            }
        }

        private void Count2()
        {
            for (var j = 0; j < N; j++)
            {
                lock (_lock)
                {
                    _count2++;
                }
            }
        }
    }
}

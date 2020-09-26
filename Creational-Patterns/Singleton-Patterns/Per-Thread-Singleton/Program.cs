using System;
using System.Threading;
using System.Threading.Tasks;

namespace Per_Thread_Singleton
{
    // Lazy<T>: Thread Safe Initialization

    public sealed class PerThreadSingleton
    {
        private static ThreadLocal<PerThreadSingleton> _threadInstance
            = new ThreadLocal<PerThreadSingleton>(() => new PerThreadSingleton());

        public int Id;

        private PerThreadSingleton()
        {
            Id = Thread.CurrentThread.ManagedThreadId;
        }

        public static PerThreadSingleton Instance => _threadInstance.Value;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var t1 = Task.Factory.StartNew(() => { Console.WriteLine($"Task-1 : {PerThreadSingleton.Instance.Id}"); });

            var t2 = Task.Factory.StartNew(() => { Console.WriteLine($"Task-2 : {PerThreadSingleton.Instance.Id}"); });

            Task.WaitAll(t1, t2);
        }
    }
}
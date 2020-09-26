using System;
using System.Threading.Tasks;

namespace Async_Factory
{
    public class Foo
    {
        private Foo()
        {
            //
        }

        private async Task<Foo> InitAsync()
        {
            await Task.Delay(1000);

            return this;
        }

        public static Task<Foo> CreateAsync()
        {
            var result = new Foo();
            return result.InitAsync();
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            await Foo.CreateAsync();
        }
    }
}
using System;
using System.Threading.Tasks;

namespace testcsharp
{
    internal class AsyncExampleHeavyComputation
    {
        public async Task run()
        {
            //It should run a Task passing a lambda expression
            //that performs the async compuntation
            await Task.Run(() => heavyComputation());
        }

        private void heavyComputation()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}

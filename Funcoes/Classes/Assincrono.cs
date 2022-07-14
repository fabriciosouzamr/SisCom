using System;
using System.Threading.Tasks;

namespace Funcoes._Classes
{
    public static class Assincrono
    {
        public static async Task TaskAsyncAndAwaitAsync(Task<bool> task)
        {
            var ret = await task;
        }

        public static Task TaskAsyncAndAwaitAsync(Func<Task> inicializaAsync)
        {
            throw new NotImplementedException();
        }
    }
}

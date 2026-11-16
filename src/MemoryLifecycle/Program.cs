using System;
using System.Threading.Tasks;
using MemoryLifecycle.Demos;

namespace MemoryLifecycle
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== КТ №43. Паттерн Dispose и IAsyncDisposable ===\n");
            
            await DisposeDemos.RunAllDemosAsync();
            
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
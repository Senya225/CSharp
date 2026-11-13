using System;
using MemoryLifecycle.Gc;

namespace MemoryLifecycle
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isServer = System.Runtime.GCSettings.IsServerGC;
            string mode = isServer ? "SERVER GC" : "WORKSTATION GC";

            Console.WriteLine("==================================================");
            Console.WriteLine($" ТЕКУЩИЙ РЕЖИМ: {mode}");
            Console.WriteLine("==================================================");
            Console.WriteLine();

            GcModeScenarios.RunParallelAllocation();
            
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
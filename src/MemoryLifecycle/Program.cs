using System;
using MemoryLifecycle.Demos;

namespace MemoryLifecycle
{
    class Program
    {
        static void Main(string[] args)
        {
            string logPath = "test_log.txt"; 
            ResourceDemos.RunLogFileDemo(logPath);
            
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
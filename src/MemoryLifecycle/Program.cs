using System;
using System.Threading.Tasks;
using MemoryLifecycle.Demos;

namespace MemoryLifecycle
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Выбор сценария для отчета ===");
                Console.WriteLine("1. КТ №41. Сравнение Workstation и Server GC (Многопоточная аллокация)");
                Console.WriteLine("2. КТ №42. Лог-файл (Финализатор и using)");
                Console.WriteLine("3. КТ №43. Паттерн Dispose и IAsyncDisposable");
                Console.WriteLine("0. Выход");
                Console.Write("\nВведите номер сценария: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        // Запуск сценария КТ 41 (из твоего GcModeScenarios)
                        MemoryLifecycle.Gc.GcModeScenarios.RunParallelAllocation();
                        Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        // Запуск сценария КТ 42
                        ResourceDemos.RunLogFileDemo("test_log.txt");
                        Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        // Запуск сценария КТ 43
                        await DisposeDemos.RunAllDemosAsync();
                        Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                        Console.ReadKey();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Неверный ввод. Нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
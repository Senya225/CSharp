using MemoryLifecycle.Resources;

namespace MemoryLifecycle.Demos;

public static class ResourceDemos
{
    public static void RunLogFileDemo(string path)
    {
        Console.WriteLine();
        Console.WriteLine("4. LogFile: корректный и некорректный сценарии");

        // 1. КОРРЕКТНЫЙ СЦЕНАРИЙ (через using)
        // Файл автоматически закроется после выхода из блока
        using (var log = new LogFile(path))
        {
           log.Write("Корректная запись через using");
        }
        Console.WriteLine("После корректного using-блока");

        // 2. НЕКОРРЕКТНЫЙ СЦЕНАРИЙ (забыли Dispose)
        CreateLogFileWithoutDispose(path);
        Console.WriteLine("Метод с забытым Dispose завершён");
        
        // Принудительно вызываем сборку мусора, чтобы сработал финализатор
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("После сборки: сработал финализатор");
    }

    private static void CreateLogFileWithoutDispose(string path)
    {
        var log = new LogFile(path);
        log.Write("Запись без using: Dispose не вызван");
        // Объект удерживается до конца метода
        GC.KeepAlive(log);
    }
}
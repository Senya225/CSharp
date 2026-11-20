using System;
using System.Threading.Tasks;
using MemoryLifecycle.Resources;

namespace MemoryLifecycle.Demos;

public static class DisposeDemos
{
    public static async Task RunAllDemosAsync()
    {
        Console.WriteLine("1. Синхронный сценарий using (DatabaseConnection)");
        using (var conn = new DatabaseConnection())
        {
            conn.Execute("SELECT * FROM Students");
        }
        
        Console.WriteLine("\n2. Асинхронный сценарий await using (DatabaseConnection)");
        await using (var conn = new DatabaseConnection())
        {
            conn.Execute("SELECT * FROM Topics");
            await Task.Delay(1);
        }

        Console.WriteLine("\n3. Проверка GC.SuppressFinalize после using");
        using (var conn = new DatabaseConnection())
        {
            conn.Execute("SELECT 1");
        }
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("После сборки: сообщение финализатора отсутствует (ресурсы уже закрыты)");

        Console.WriteLine("\n4. Финализатор без Dispose (DatabaseConnection)");
        CreateConnectionWithoutDispose();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("После сборки: финализатор освободил только нативный ресурс");

        Console.WriteLine("\n5. Синхронный и асинхронный FileBuffer");
        using (var buffer = new FileBuffer())
        {
            buffer.Write(new byte[] { 1, 2, 3, 4 });
        }

        await using (var buffer = new FileBuffer())
        {
            buffer.Write(new byte[] { 5, 6, 7 });
            await Task.Delay(1);
        }
    }

    private static void CreateConnectionWithoutDispose()
    {
        var conn = new DatabaseConnection();
        conn.Execute("UPDATE Students SET Name = 'Test'");
        GC.KeepAlive(conn);
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemoryLifecycle.Resources;

public sealed class DatabaseConnection : IDisposable, IAsyncDisposable
{
    private static int counter;
    private readonly int connectionId = ++counter;
    private readonly List<string> queryLog = new();
    private bool disposed;

    public DatabaseConnection()
    {
        Console.WriteLine($"[DatabaseConnection {connectionId}] соединение открыто");
    }

    public void Execute(string query)
    {
        ObjectDisposedException.ThrowIf(disposed, this);
        queryLog.Add(query);
        Console.WriteLine($"[DatabaseConnection {connectionId}] запрос: {query}");
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        try
        {
            await DisposeAsyncCore().ConfigureAwait(false);
        }
        finally
        {
            Dispose(disposing: false);
            GC.SuppressFinalize(this);
        }
    }

    private void Dispose(bool disposing)
    {
        if (disposed) return;

        if (disposing)
        {
            queryLog.Clear();
            Console.WriteLine($"[DatabaseConnection {connectionId}] журнал запросов очищен (синхронно)");
        }

        disposed = true;
        Console.WriteLine($"[DatabaseConnection {connectionId}] соединение закрыто (нативный ресурс)");
    }

    private async ValueTask DisposeAsyncCore()
    {
        if (disposed) return;
        
        await Task.Delay(10).ConfigureAwait(false); // Имитация асинхронного закрытия
        queryLog.Clear();
        Console.WriteLine($"[DatabaseConnection {connectionId}] журнал запросов очищен (асинхронно)");
    }

    ~DatabaseConnection()
    {
        Dispose(disposing: false);
    }
}
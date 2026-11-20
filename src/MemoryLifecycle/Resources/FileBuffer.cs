using System;
using System.IO;
using System.Threading.Tasks;

namespace MemoryLifecycle.Resources;

public sealed class FileBuffer : IDisposable, IAsyncDisposable
{
    private static int counter;
    private readonly int fileHandle = ++counter;
    private MemoryStream? buffer = new();
    private bool disposed;

    public FileBuffer()
    {
        Console.WriteLine($"[FileBuffer {fileHandle}] буфер открыт");
    }

    public void Write(ReadOnlySpan<byte> data)
    {
        ObjectDisposedException.ThrowIf(disposed, this);
        buffer!.Write(data);
        Console.WriteLine($"[FileBuffer {fileHandle}] записано {data.Length} байт");
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
            buffer?.Dispose();
            buffer = null;
            Console.WriteLine($"[FileBuffer {fileHandle}] буфер освобожден (синхронно)");
        }

        disposed = true;
        Console.WriteLine($"[FileBuffer {fileHandle}] нативный дескриптор закрыт");
    }

    private async ValueTask DisposeAsyncCore()
    {
        if (disposed) return;
        
        await Task.Delay(10).ConfigureAwait(false);
        buffer?.Dispose();
        buffer = null;
        Console.WriteLine($"[FileBuffer {fileHandle}] буфер освобожден (асинхронно)");
    }

    ~FileBuffer()
    {
        Dispose(disposing: false);
    }
}
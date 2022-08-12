namespace TauCode.IO;

public class TextRelay : IDisposable
{
    public TextRelay(TextReader reader, TextWriter output)
    {
        this.Reader = reader ?? throw new ArgumentNullException(nameof(reader));
        this.Output = output ?? throw new ArgumentNullException(nameof(output));
    }

    public TextReader Reader { get; set; }

    public TextWriter Output { get; }

    public bool IsRunning { get; private set; }

    public void Start()
    {
        if (this.IsRunning)
        {
            throw new InvalidOperationException();
        }

        var task = new Task(this.Routine, null);
        task.Start();
    }

    public void Stop()
    {
        try
        {
            this.Dispose();
        }
        catch
        {
            // ignore
        }

        this.IsRunning = false;
    }

    private void Routine(object? obj)
    {
        Span<char> buffer = stackalloc char[4096];

        try
        {
            while (true)
            {
                var charsRead = this.Reader.Read(buffer);
                ReadOnlySpan<char> spanToRelay = buffer[..charsRead];
                this.Output.Write(spanToRelay);
            }
        }
        catch
        {
            this.Stop();
        }
    }

    public void Dispose()
    {
        Reader.Dispose();
        Output.Dispose();
    }
}
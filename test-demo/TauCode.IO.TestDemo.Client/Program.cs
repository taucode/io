using Serilog;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TauCode.IO.TestDemo.Client;

public class Program
{
    private static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;

        var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.Connect(IPAddress.Loopback, 5555);

        var stream = new NetworkStream(socket);
        var writer = new StreamWriter(stream);

        var log = new LoggerConfiguration()
            .WriteTo.TextWriter(writer)
            .CreateLogger();
        Log.Logger = log;

        Console.WriteLine("Connected to Server.");

        while (true)
        {
            Console.Write(" > ");
            var text = Console.ReadLine();
            Log.Information(text);
        }
    }
}
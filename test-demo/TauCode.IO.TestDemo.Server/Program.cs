using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TauCode.IO.TestDemo.Server;

public class Program
{
    private static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;

        var listener = new TcpListener(new IPEndPoint(IPAddress.Loopback, 5555));
        listener.Start();

        while (true)
        {
            var socket = listener.AcceptSocket();
            Console.WriteLine("Connected. Local: {0}, Remote: {1}.", socket.LocalEndPoint, socket.RemoteEndPoint);

            var stream = new NetworkStream(socket, true);
            var reader = new StreamReader(stream);

            var relay = new TextRelay(reader, Console.Out);
            relay.Start();
        }
    }
}
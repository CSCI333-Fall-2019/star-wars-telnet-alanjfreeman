using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace StarWarsTelnet
{
    class Program
    {
        static void Main(string[] args)
        {
            // variable initialization
            Byte[] output = new Byte[1024];
            string response = String.Empty;
            string url = "towel.blinkenlights.nl";
            int port = 23;

            // Create TCP Client
            var client = new TcpClient(url, port);
            NetworkStream ns = client.GetStream();
            Byte[] cmd = System.Text.Encoding.ASCII.GetBytes("\n");
            ns.Write(cmd, 0, cmd.Length);

            // Get output
            Int32 bytes = ns.Read(output, 0, output.Length);

            while (bytes > 0)
            {
                Console.Clear();
                response = System.Text.Encoding.ASCII.GetString(output);
                Console.WriteLine(response);
                bytes = ns.Read(output, 0, output.Length);
            }
        }
    }
}

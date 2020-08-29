using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClienteZMQ
{
    static class Servidor
    {
        public static void Main()
        {
            Console.WriteLine("Connecting to hello world server…");
            using (var requester = new RequestSocket())
            {
                requester.Connect("tcp://localhost:5555");
                Console.WriteLine("Se conectó");

                Console.WriteLine("Sending Hello");
                requester.SendFrame("Hello");
                string str = requester.ReceiveFrameString();
                Console.WriteLine(str);
                //Console.WriteLine("Received World {0}", requestNumber);

            }
        }
    }
}

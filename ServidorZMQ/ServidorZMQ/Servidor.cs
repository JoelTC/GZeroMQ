using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServidorZMQ
{
    static class Servidor
    {
        public static void Main()
        {
            var jeison = new Json
            {
                id_producto = 1,
                id_cliente = 12345678,
                nombre = "Joel",
                cantidad = 2,
                diferencia = 5
            };

            string json = JsonConvert.SerializeObject(jeison);

            using (var responder = new ResponseSocket())
            {
                responder.Bind("tcp://*:5555");

                while (true)
                {
                    string str = responder.ReceiveFrameString();
                    Console.WriteLine(str);
                    //Console.WriteLine("Received Hello");
                    Thread.Sleep(1000);  //  Do some 'work'
                    responder.SendFrame(json);
                }
            }
        }
    }
}

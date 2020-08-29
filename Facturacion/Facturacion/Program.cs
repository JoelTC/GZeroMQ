using Facturacion.Entidades;
using Facturacion.LogicaNegocio;
using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Facturacion
{
    public class Program
    {
        static Pruebas_facturacion pruebasf = new Pruebas_facturacion();
        static void Main(string[] args)
        {
            //pruebasf.ListarFactura(12345678);
            //pruebasf.InsertarFactura();
            //pruebasf.MaxFactura();

            Console.WriteLine("Connecting to hello world server…");
            using (var requester = new RequestSocket())
            {
                requester.Connect("tcp://localhost:5555");
                Console.WriteLine("Se conectó");

                Console.WriteLine("Sending Hello");
                requester.SendFrame("Hello");
                string str = requester.ReceiveFrameString();
                Console.WriteLine(str);
                Console.WriteLine("Recibido");
                Json jeison = JsonConvert.DeserializeObject<Json>(str);
                Console.WriteLine(jeison.id_cliente);
                Console.WriteLine(jeison.id_producto);
                Console.WriteLine(jeison.nombre);
                Console.WriteLine(jeison.cantidad);
                Console.WriteLine(jeison.diferencia);
                

            }
        }
    }
}

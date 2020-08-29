using Facturacion.Entidades;
using Facturacion.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion
{
    public class Pruebas_facturacion
    {
        DetalleFacturaLN dfacturaBL = new DetalleFacturaLN();
        FacturaLN facturaBL = new FacturaLN();

        public void ListarFactura(int dni)
        {
            List<EDetalleFactura> dfactura = dfacturaBL.Todos(dni);

            foreach (var item in dfactura)
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine(item.nom_prod + "\t\t" + item.prec_prod + "\t" + item.cantidad + "\t" + item.monto);
                Console.WriteLine("---------------------------------------------------- \n");
            }
        }

        public void InsertarFactura()
        {
            EFactura factura = new EFactura();
            factura.id_cliente = 12345678;
            factura.estado_fac = "Sin cancelar";
            factura.monto_pag = 0;

            facturaBL.InsertarFactura(factura);
            Console.WriteLine("Se insertó nueva factura");
        }

        public void MaxFactura()
        {
            Console.WriteLine(facturaBL.MaxFactura());
        }
    }
}

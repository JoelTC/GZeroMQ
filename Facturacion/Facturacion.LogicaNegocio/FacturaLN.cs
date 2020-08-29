using System;
using System.Collections.Generic;
using System.Text;
using Facturacion.AccesoDatos;
using Facturacion.Entidades;

namespace Facturacion.LogicaNegocio
{
    public class FacturaLN
    {
        FacturaDA facturaDA = new FacturaDA();
        public void InsertarFactura(EFactura factura)
        {
            facturaDA.InsertarFactura(factura);
        }

        public int MaxFactura()
        {
            return facturaDA.MaxFactura();
        }
    }
}

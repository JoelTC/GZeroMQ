﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Entidades
{
    public class EOrden
    {
        public int id_orden { get; set; }
        public int id_factura { get; set; }
        public int id_producto { get; set; }
        public double cantidad { get; set; }
        public double costo { get; set; }
    }
}

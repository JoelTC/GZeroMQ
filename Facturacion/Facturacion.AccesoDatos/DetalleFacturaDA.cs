﻿using Facturacion.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.AccesoDatos
{
    public class DetalleFacturaDA : ConexionToMySQL
    {
        public List<EDetalleFactura> GetAll(int dni)
        {
            List<EDetalleFactura> facturas = new List<EDetalleFactura>();

            using (var conexion = GetConnection())
            {
                conexion.Open();

                MySqlCommand cmd = new MySqlCommand("call sp_detalle_factura_list(@dni)", conexion);
                cmd.Parameters.AddWithValue("@dni", dni);
                MySqlDataReader lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    EDetalleFactura detalleFactura = new EDetalleFactura
                    {
                        id_fac = Convert.ToInt32(lector["FACTURA"]),
                        id_cli = Convert.ToInt32(lector["DNI"]),
                        cliente = Convert.ToString(lector["CLIENTE"]),
                        nom_prod = Convert.ToString(lector["PRODUCTO"]),
                        prec_prod = Convert.ToDouble(lector["PRECIO"]),
                        cantidad = Convert.ToDouble(lector["CANTIDAD"]),
                        monto = Convert.ToDouble(lector["COSTO"]),
                        total = Convert.ToDouble(lector["TOTAL"]),
                        abonado = Convert.ToDouble(lector["ABONADO"]),
                        cuenta = Convert.ToDouble(lector["CUENTA"])
                    };

                    facturas.Add(detalleFactura);
                }
            }
            return facturas;
        }
    }
}

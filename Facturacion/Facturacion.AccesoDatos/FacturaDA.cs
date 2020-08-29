using Facturacion.Entidades;
using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.AccesoDatos
{
    public class FacturaDA : ConexionToMySQL
    {
        public void InsertarFactura (EFactura factura)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();

                MySqlCommand cmd = new MySqlCommand("insert into tb_facturas (fk_id_cli, est_fct, mnt_pgd) values (@dni, @estado, @monto)", conexion);
                cmd.Parameters.AddWithValue("@dni", factura.id_cliente);
                cmd.Parameters.AddWithValue("@estado", factura.estado_fac);
                cmd.Parameters.AddWithValue("@monto", factura.monto_pag);
                cmd.ExecuteNonQuery();
            }
        }

        public int MaxFactura()
        {
            int id_max;
            using (var conexion = GetConnection())
            {
                conexion.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT MAX(ID_FCT) AS MAX FROM TB_FACTURAS", conexion);
                MySqlDataReader lector = cmd.ExecuteReader();
                if (lector.Read())
                {
                    id_max = Convert.ToInt32(lector["MAX"]);
                    return id_max;
                }
            }
            return 0;
        }
    }
}

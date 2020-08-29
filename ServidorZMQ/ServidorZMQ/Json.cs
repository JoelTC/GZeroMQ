using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorZMQ
{
    public class Json
    {
        public int id_producto { get; set; }
        public int id_cliente { get; set; }
        public string nombre { get; set; }
        public int cantidad { get; set; }
        public int diferencia { get; set; }
    }
}

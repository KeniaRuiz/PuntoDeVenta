using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    class Producto
    {
        private int id;
        private String codigo;
        private string nombre;
        private decimal precio;

        public int Id { get => id; set => id = value; }
        public String Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal Precio { get => precio; set => precio = value; }
    }
}

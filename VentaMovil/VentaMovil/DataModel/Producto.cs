using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaMovil.Common;

namespace VentaMovil.DataModel
{

    [Table("Productos")]
    public class Producto:Observable
    {

        private int _IdProducto;
        [PrimaryKey]
        public int IdProducto
        {
            get { return _IdProducto; }
            set { _IdProducto = value; }
        }

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private float _Precio;

        public float Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        private float _Inventario;

        public float Inventario
        {
            get { return _Inventario; }
            set { _Inventario = value; }
        }


    }
}

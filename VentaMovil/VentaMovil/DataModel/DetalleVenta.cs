using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaMovil.Common;

namespace VentaMovil.DataModel
{
    [Table("DetalleVentas")]
    public class DetalleVenta:Observable

    {

        private int _IdDetalleVenta;
        [PrimaryKey]
        public int IdDetalleVenta
        {
            get { return _IdDetalleVenta; }
            set { _IdDetalleVenta = value; }
        }

        private int _IdVenta;

        public int IdVenta
        {
            get { return _IdVenta; }
            set { _IdVenta = value; }
        }

        private int _IdProducto;

        public int IdProducto
        {
            get { return _IdProducto; }
            set { _IdProducto = value; }
        }

        private float _Cantidad;

        public float Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        private float _PrecioUnitario;

        public float PrecioUnitario
        {
            get { return _PrecioUnitario; }
            set { _PrecioUnitario = value; }
        }




    }
}

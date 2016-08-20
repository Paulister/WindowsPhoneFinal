using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaMovil.Common;

namespace VentaMovil.DataModel
{
    [Table("Ventas")]
    public class Venta:Observable
    {

        private int _IdVenta;
        [PrimaryKey]
        public int IdVenta
        {
            get { return _IdVenta; }
            set { _IdVenta = value; }
        }

        private int _IdCliente;

        public int IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }

        private string _Fecha;

        public string Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private float _Total;

        public float Total
        {
            get { return _Total; }
            set { _Total = value; }
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaMovil.Common;
using VentaMovil.DataAccess;
using VentaMovil.DataModel;
using System.Collections.ObjectModel;

namespace VentaMovil.ViewModel
{
    public class ProductosViewModel:Observable
    {
        AccesoLocal AL = new AccesoLocal();
        public ObservableCollection<Producto> Productos { get; private set; }
        public ProductosViewModel()
        {
            this.Productos = new ObservableCollection<Producto>();
            List<Producto> producto = AL.ListaProductos();
            this.Productos.Clear();
            foreach (Producto c in producto)
            {
                this.Productos.Add(c);
            }
        }
    }
}

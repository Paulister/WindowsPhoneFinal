using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaMovil.Common;
using VentaMovil.DataAccess;
using VentaMovil.DataModel;

namespace VentaMovil.ViewModel
{
   public class ClientesViewModel:Observable
    {
        AccesoLocal AL = new AccesoLocal();
        public ObservableCollection<Cliente> Clientes { get; private set; }
        public ClientesViewModel()
        {

            this.Clientes = new ObservableCollection<Cliente>();
            List<Cliente> cliente = AL.ListaClientes();

            this.Clientes.Clear();

            foreach (Cliente c in cliente)
            {
                this.Clientes.Add(c);
            }

        }
        public void CargaDatos()
        {

            
        }


    }
}

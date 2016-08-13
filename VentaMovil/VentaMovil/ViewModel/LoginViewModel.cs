using VentaMovil.Common;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaMovil.DataModel
{
    public class LoginViewModel : Observable
    {
        private SQLiteConnection db;

        public ObservableCollection<Usuario> Usuarios { get; private set; }

        public bool ValidaBase()
        {
            bool Resultado;
            List<Usuario> usuarios = db.Table<Usuario>().ToList<Usuario>();
            this.Usuarios.Clear();

            if(usuarios == null)
            {
                Resultado = false;
            }
            else
            {
                Resultado = true;
            }

            return Resultado;
        }
    }
}

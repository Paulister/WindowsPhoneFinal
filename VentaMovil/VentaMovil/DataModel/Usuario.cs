using VentaMovil.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace VentaMovil.DataModel
{
    [Table("Usuarios")]
    public class Usuario : Observable
    {
        private int _IdUsuario;
        [PrimaryKey]
        public int IdUsuario
        {
            get { return _IdUsuario; }
            set
            {
                _IdUsuario = value;
                NotifyPropertyChanged("IdUsuario");
            }
        }

        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set
            {
                _Nombre = value;
                NotifyPropertyChanged("Nombre");
            }
        }

        private string _telefono;
        public string Telefono
        {
            get { return _telefono; }
            set
            {
                _telefono = value;
                NotifyPropertyChanged("Telefono");
            }
        }

        private string _Contrasenia;
        public string Contrasenia
        {
            get { return _Contrasenia; }
            set
            {
                _Contrasenia= value;
                NotifyPropertyChanged("Contrasenia");
            }
        }
    }
}

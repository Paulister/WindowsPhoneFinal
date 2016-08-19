using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using VentaMovil.Common;

namespace VentaMovil.DataModel
{
    [Table("Clientes")]
    public class Cliente : Observable
    {
        private int _IdCliente;
        [PrimaryKey]
        public int IdCliente
        {
            get { return _IdCliente; }
            set
            {
                _IdCliente = value;
                NotifyPropertyChanged("IdCliente");
            }
        }
        private string _NombreCompleto;

        public string NombreCompleto
        {
            get { return _NombreCompleto; }
            set
            {
                _NombreCompleto = value;
                NotifyPropertyChanged("NombreCompleto");
            }
        }
        private string _RFC;

        public string RFC
        {
            get { return _RFC; }
            set
            {
                _RFC = value;
                NotifyPropertyChanged("RFC");
            }
        }



    }
}

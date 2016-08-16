﻿using VentaMovil.Common;
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
        [PrimaryKey, AutoIncrement]
        public int IdUsuario
        {
            get { return _IdUsuario; }
            set
            {
                _IdUsuario = value;
                NotifyPropertyChaged("IdUsuario");
            }
        }

        private string _User;
        public string User
        {
            get { return _User; }
            set
            {
                _User = value;
                NotifyPropertyChaged("Usuario");
            }
        }

        private string _telefono;
        public string Telefono
        {
            get { return _telefono; }
            set
            {
                _telefono = value;
                NotifyPropertyChaged("Telefono");
            }
        }

        private string _Contraseña;
        public string Contraseña
        {
            get { return _Contraseña; }
            set
            {
                _Contraseña= value;
                NotifyPropertyChaged("Contraseña");
            }
        }
    }
}
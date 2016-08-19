﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaMovil.DataModel;
using SQLite;
using Windows.Storage;
using System.IO;
using VentaMovil.Common;

namespace VentaMovil.DataAccess
{
    class AccesoLocal
    {
        private String DB_NAME = "VentaMovil.db";
        string connstring = Path.Combine(ApplicationData.Current.LocalFolder.Path, "VentaMovil.db");

        public SQLiteAsyncConnection Conn { get; set; }

        public AccesoLocal()
        {
            Conn = new SQLiteAsyncConnection(DB_NAME);
            this.InitDb();

        }

        public async void InitDb()
        {
            // Crear Base si no existe
            bool dbExiste = await CheckDbAsync();
            if (!dbExiste)
            {
                await CreateDatabaseAsync();
            }
        }

        public async Task<bool> CheckDbAsync()
        {
            bool dbExist = true;

            try
            {
                StorageFile sf = await ApplicationData.Current.LocalFolder.GetFileAsync(DB_NAME);
            }
            catch (Exception)
            {
                dbExist = false;
            }

            return dbExist;
        }

        private async Task CreateDatabaseAsync()
        {
            //Crea Tabla Usuario

         await Conn.CreateTableAsync<Usuario>();
            //Crea Tabla Cliente
            //await Conn.CreateTableAsync<Cliente>();

        }


        public void AddUsuario(Usuario Usuar)
        {

        //Insert en la base de Datos
         SQLiteConnection db = new SQLiteConnection(connstring, true);
         //DeleteUsuario(Usuar);
         db.Insert(Usuar);


        }

 
        public void DeleteUsuario(Usuario Usuar)
        {
            using (var dbConn = new SQLiteConnection(connstring))
            {
                var us = dbConn.Query<Usuario>("select * from Usuarios where Nombre =" +Usuar.Nombre ).FirstOrDefault();
                if (us != null)
                {
                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Delete(us);
                    });
                }
            }
        }

        public bool Login(Usuario Usuar)
        {
            bool log = false;
            using (var dbConn = new SQLiteConnection(connstring))
            {
                var us = dbConn.Query<Usuario>("select * from Usuarios where Nombre ='" + Usuar.Nombre.ToString()+"'").FirstOrDefault();
                if (us != null)
                {
                    if (us.Contrasenia==Usuar.Contrasenia)
                    {
                        log = true;
                    }
                }

                return log;
            }
        }

        public bool ExisteUs()
        {
            bool log = false;
            using (var dbConn = new SQLiteConnection(connstring))
            {
               
                    var us = dbConn.Query<Usuario>("select * from Usuarios").FirstOrDefault();
                    if (us != null)
                    {
                        log = true;
                    }
            
                return log;
            }
        }

        public void BorrarUsuarios()
        {
            using (var dbConn = new SQLiteConnection(connstring))
            {
                dbConn.DropTable<Usuario>();
                dbConn.CreateTable<Usuario>();
            }
        }


    }
}

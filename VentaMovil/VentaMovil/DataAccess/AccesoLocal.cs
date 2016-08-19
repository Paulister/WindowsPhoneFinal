using System;
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
            await Conn.CreateTableAsync<Cliente>();

        }
       

    }
}

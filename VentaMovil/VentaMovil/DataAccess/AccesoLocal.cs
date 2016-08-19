using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaMovil.DataModel;

namespace VentaMovil.DataAccess
{
    class AccesoLocal
    {
        private async void CrearUsBD()
        {
            var folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var conn = new SQLite.SQLiteAsyncConnection(
                System.IO.Path.Combine(folder.Path, "VentaMovil.db"));
            await conn.CreateTableAsync<Usuario>();
        }
    }
}

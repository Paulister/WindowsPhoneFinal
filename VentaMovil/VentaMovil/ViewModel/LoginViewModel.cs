using VentaMovil.Common;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using VentaMovil.DataAccess;
using System.Net.Http;
using Newtonsoft.Json;

namespace VentaMovil.DataModel
{
    public class LoginViewModel : Observable
    {
        AccesoLocal AL = new AccesoLocal();
        public async Task<bool> ExisteDB()
        {

            bool dbExist = true;
            try
            {
                StorageFile sf = await ApplicationData.Current.LocalFolder.GetFileAsync("VentaMovil.db");
            }
            catch (Exception)
            {
                //Si no existe se crea la Base
                dbExist = false;
                AL.InitDb();
            }

            return dbExist;
        }

        //Importar Usuario a BD Local verificando si existe usuario 


        public void InsertaUsuarioBDLocal(Usuario us)
        { 
            AL.AddUsuario(us);
        }
        public bool CheckUS ()
        {
            bool existe = AL.ExisteUs();
            return existe;
        }

        public bool InicioSesion(Usuario us)
        {
            bool ok = AL.Login(us);
            return ok;
        }

        //Importar Clientes a BD Local


        public void InsertaClientesBDLocal(List<Cliente> Cli)
        {
            AL.InsertarClientesBDLocal(Cli);
        }

        //Importar Productos a BD Local
        public void InsertaProductosBDLocal(List<Producto> Pro)
        {
            AL.InsertarProductosBDLocal(Pro);
        }



    }
}

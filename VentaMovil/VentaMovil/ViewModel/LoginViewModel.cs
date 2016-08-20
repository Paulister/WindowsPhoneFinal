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
        public async Task<Usuario> GetUsuarioByTel(string NumTelefono)
        {
            HttpClient client = new HttpClient();
            Uri dataUri = new Uri("http://localhost:50305/WSVentasRuta.svc/GetUsuarioByTel/" + NumTelefono);
            string jsonText = await client.GetStringAsync(dataUri);
            Usuario Usu = JsonConvert.DeserializeObject<Usuario>(jsonText);
            return Usu;
        }

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
        public async Task<List<Cliente>> GetClientesById(string IdUsuario)
        {
            HttpClient client = new HttpClient();
            Uri dataUri = new Uri("http://localhost:50305/WSVentasRuta.svc/GetClientesById/" + IdUsuario);
            string jsonText = await client.GetStringAsync(dataUri);
            List<Cliente> Clientes = JsonConvert.DeserializeObject<List<Cliente>>(jsonText);
            return Clientes;
        }

        public void InsertaClientesBDLocal(List<Cliente> Cli)
        {
            AL.InsertarClientesBDLocal(Cli);
        }

    }
    }

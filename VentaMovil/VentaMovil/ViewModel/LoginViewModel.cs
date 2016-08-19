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
                AccesoLocal AL = new AccesoLocal();
                AL.InitDb();
            }

            return dbExist;
        }


        public async Task<Usuario> GetUsuarioByTel(string NumTelefono)
        {
            HttpClient client = new HttpClient();
            Uri dataUri = new Uri("http://localhost:50305/WSVentasRuta.svc/GetUsuarioByTel/" + NumTelefono);
            string jsonText = await client.GetStringAsync(dataUri);
            Usuario Usu = JsonConvert.DeserializeObject<Usuario>(jsonText);
            return Usu;
        }




    }
    }

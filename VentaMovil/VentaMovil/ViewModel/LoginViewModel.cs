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
                dbExist = false;
                AccesoLocal AL = new AccesoLocal();
                AL.InitDb();
            }

            return dbExist;
        }


        }
    }

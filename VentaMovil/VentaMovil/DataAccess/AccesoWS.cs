using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VentaMovil.DataModel;

namespace VentaMovil.DataAccess
{
    class AccesoWS
    {

        public async Task<Usuario> GetUsuarioByTel(string NumTelefono)
        {
            HttpClient client = new HttpClient();
            Uri dataUri = new Uri("http://localhost:50305/WSVentasRuta.svc/GetUsuarioByTel/" + NumTelefono);
            string jsonText = await client.GetStringAsync(dataUri);
            Usuario Usu = JsonConvert.DeserializeObject<Usuario>(jsonText);
            return Usu;
        }
        public async Task<List<Cliente>> GetClientesById(string IdUsuario)
        {
            HttpClient client = new HttpClient();
            Uri dataUri = new Uri("http://localhost:50305/WSVentasRuta.svc/GetClientesById/" + IdUsuario);
            string jsonText = await client.GetStringAsync(dataUri);
            List<Cliente> Clientes = JsonConvert.DeserializeObject<List<Cliente>>(jsonText);
            return Clientes;
        }

        public async Task<List<Producto>> GetProductosById(string IdUsuario)
        {
            HttpClient client = new HttpClient();
            Uri dataUri = new Uri("http://localhost:50305/WSVentasRuta.svc/GetProductosById/" + IdUsuario);
            string jsonText = await client.GetStringAsync(dataUri);
            List<Producto> Productos = JsonConvert.DeserializeObject<List<Producto>>(jsonText);
            return Productos;
        }

    }
}

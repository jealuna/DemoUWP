using Claro.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace Claro.Services
{
    public class Services
    {
        public static async Task<ObservableCollection<Pelicula>> GetPeliculasCategoria(int Categoria)
        {
            using (HttpClient Client = new HttpClient())
            {
                Parametros ParametrosPost = new Parametros();
                ParametrosPost.node_id = Categoria.ToString();
                string Json = JsonConvert.SerializeObject(ParametrosPost);
                Dictionary<string, string> Diccionario = JsonConvert.DeserializeObject<Dictionary<string, string>>(Json);
                FormUrlEncodedContent EncodedContent = new FormUrlEncodedContent(Diccionario);
                string Parametros = EncodedContent.ReadAsStringAsync().Result;
                UriBuilder builder = new UriBuilder("https://mfwkweb-api.clarovideo.net/services/content/list")
                {
                    Port = -1,
                    Query = Parametros
                };
                string Url = builder.ToString();
                string Respuesta = await Client.GetStringAsync(Url);
                JObject Result = JObject.Parse(Respuesta);
                var Items = Result["response"]["groups"].Children().ToList();
                List<Pelicula> Peliculas = new List<Pelicula>();
                using (var webClient = new WebClient())
                {
                    foreach (var Item in Items)
                    {
                        Pelicula Pelicula = Item.ToObject<Pelicula>();
                        //Pelicula.Imagen = webClient.DownloadData(Pelicula.image_medium);
                        Peliculas.Add(Pelicula);
                    }
                }
                return new ObservableCollection<Pelicula>(Peliculas);
            }
        }
    }
}

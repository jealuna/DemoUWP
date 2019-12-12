using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claro.Models
{
    public class Pelicula
    {
        public int id { get; set; }
        public string title { get; set; }
        public string title_uri { get; set; }
        public string title_original { get; set; }
        public string description { get; set; }
        public string description_large { get; set; }
        public string image_medium { get; set; }
        public string image_small { get; set; }
        public byte[] Imagen { get; set; }
        public string duration { get; set; }
        public string date { get; set; }
        public string year { get; set; }
        public int votes_average { get; set; }
        public string rating_code { get; set; }
    }
}

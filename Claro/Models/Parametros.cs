using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claro.Models
{
    public class Parametros
    {
        [JsonProperty]
        public const string device_id = "web";
        [JsonProperty]
        public const string device_category = "web";
        [JsonProperty]
        public const string device_model = "web";
        [JsonProperty]
        public const string device_type = "web";
        [JsonProperty]
        public const string format = "json";
        [JsonProperty]
        public const string device_manufacturer = "generic";
        [JsonProperty]
        public const string authpn = "webclient";
        [JsonProperty]
        public const string authpt = "tfg1h3j4k6fd7";
        [JsonProperty]
        public const string api_version = "v5.88";
        [JsonProperty]
        public const string region = "mexico";
        [JsonProperty]
        public const string HKS = "p7a59rs0rafbdl6jujit1tp0f1";
        [JsonProperty]
        public const string quantity = "40";
        [JsonProperty]
        public const string order_way = "DESC";
        [JsonProperty]
        public const string order_id = "200";
        [JsonProperty]
        public const string level_id = "GPS";
        [JsonProperty]
        public const string from = "0";
        [JsonProperty]
        public string node_id { get; set; }
    }
}

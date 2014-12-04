using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingCollectorConfig

{
    [System.Reflection.ObfuscationAttribute(Feature = "properties renaming")]
    class PingCollectorResponse
    {
        [JsonProperty(PropertyName = "message")]
        public String message { get; set; }
        [JsonProperty(PropertyName = "code")]
        public int code { get; set; }
        [JsonProperty(PropertyName = "error")]
        public Boolean error { get; set; }

    }

    
}

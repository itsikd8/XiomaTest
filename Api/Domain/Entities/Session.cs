using System;
using System.Text.Json.Serialization;

namespace Api.Domain.Entities
{
    public class Session
    {
        [JsonPropertyName("odata.metadata")]
        public string OdataMetadata { get; set; }
        public string SessionId { get; set; }
        public string Version { get; set; }
        public int SessionTimeout { get; set; }
    }
}

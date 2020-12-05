using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class BusinessPartnersDto
    {
        [JsonPropertyName("odata.metadata")]
        public string OdataMetadata { get; set; }
        public List<BPDetails> value { get; set; }
    }
}

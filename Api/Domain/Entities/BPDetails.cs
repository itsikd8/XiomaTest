using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class BPDetails
    {
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string CardType { get; set; }
        public int GroupCode { get; set; }
        public object Address { get; set; }
        public object ZipCode { get; set; }
        public object MailAddress { get; set; }
        public object MailZipCode { get; set; }
        public object Phone1 { get; set; }
        public object Phone2 { get; set; }
    }
}

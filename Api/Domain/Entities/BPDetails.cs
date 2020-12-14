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
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string MailAddress { get; set; }
        public string MailZipCode { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
    }
}

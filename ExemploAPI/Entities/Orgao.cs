using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDocker.Entities
{
    public class Orgao
    {
        public int OrgaoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlSite { get; set; }
        public string Email { get; set; }
        public string TelefonePrincipal { get; set; }
        public string TelefoneAlternativo { get; set; }
        public int Destaque { get; set; }
        public byte[] Logo { get; set; }
        public string LogoType { get; set; }
    }
}

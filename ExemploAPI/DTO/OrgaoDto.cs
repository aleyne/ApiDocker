using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDocker.DTO
{
    public record OrgaoSemLogo(int OrgaoId, string Nome, string Descricao,
        string UrlSite, string Email, string TelefonePrincipal,
        string TelefoneAlternativo, int Destaque);

    public record OrgaoComLogo(int OrgaoId, string Nome, string Descricao,
        string UrlSite, string Email, string TelefonePrincipal,
        string TelefoneAlternativo, int Destaque, byte[] Logo, string LogoType);
}
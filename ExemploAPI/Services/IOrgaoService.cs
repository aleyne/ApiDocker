using ApiDocker.DTO;
using System.Collections.Generic;

namespace ApiDocker.Services
{
    public interface IOrgaoService
    {
        /// <summary>
        /// Metodo para obter todos os orgãos sem o binario da logo
        /// </summary>
        /// <returns></returns>
        List<OrgaoSemLogo> ObterTodosOrgaos();

        /// <summary>
        /// Metodo para obter um orgão por Id
        /// </summary>
        /// <returns></returns>
        OrgaoComLogo ObterOrgaoPorId(int id);
    }
}

using ApiDocker.Entities;
using ApiDocker.Infra.Interfaces;

namespace ApiDocker.Infra.Repositories
{
    public class OrgaoRepository : RepositoryBase<Orgao>, IOrgaoRepository
    {
        public OrgaoRepository(APIContext context) : base(context) { }
    }
}

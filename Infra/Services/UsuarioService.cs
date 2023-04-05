using Infra.Entities;
using Infra.Interfaces;

namespace Infra.Services
{
    internal class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository repository) : base(repository)
        {
        }
    }
}

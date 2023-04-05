using Infra.Entities;
using Infra.Interfaces;

namespace Infra.Services
{
    internal class TarefaService : BaseService<Tarefa>, ITarefaService
    {
        public TarefaService(ITarefaRepository repository) : base(repository)
        {
        }
    }
}

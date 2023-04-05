using Infra.Entities;
using Infra.Interfaces;

namespace Infra.Services
{
    internal class HistoricoTarefaService : BaseService<HistoricoTarefa>, IHistoricoTarefaService
	{
        public HistoricoTarefaService(IHistoricoTarefaRepository repository) : base(repository)
        {
        }
    }
}

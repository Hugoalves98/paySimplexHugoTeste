using Infra.Entities;
using Infra.Interfaces;

namespace Infra.Services
{
    internal class HistoricoTarefaService : BaseService<HistoricoTarefa>, IHistoricoTarefaService
	{
        private IHistoricoTarefaRepository _repository;
        public HistoricoTarefaService(IHistoricoTarefaRepository repository) : base(repository)
        {
            _repository = repository;
        }
        public HistoricoTarefa? BuscaUltimaTarefaPorId(int tarefaId) => _repository.BuscaUltimaTarefaPorId(tarefaId);

	}
}

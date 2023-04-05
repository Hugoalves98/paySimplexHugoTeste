using Infra.Entities;

namespace Infra.Interfaces
{
    public interface IHistoricoTarefaService : IBaseService<HistoricoTarefa>
    {
		public HistoricoTarefa? BuscaUltimaTarefaPorId(int tarefaId);

	}
}

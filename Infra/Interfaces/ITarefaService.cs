using Infra.Entities;

namespace Infra.Interfaces
{
    public interface ITarefaService : IBaseService<Tarefa>
    {
		public Tarefa AtualizarTarefa(Tarefa tarefa);
	}
}

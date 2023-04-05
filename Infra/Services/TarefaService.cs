using Infra.Entities;
using Infra.Interfaces;

namespace Infra.Services
{
    internal class TarefaService : BaseService<Tarefa>, ITarefaService
    {
		private readonly ITarefaRepository _tarefaRepository;
		public TarefaService(ITarefaRepository repository) : base(repository)
        {
			_tarefaRepository = repository;

		}

		public Tarefa AtualizarTarefa(Tarefa tarefa)
		{
			try
			{
				if (tarefa.Id != null)
					throw new Exception("Id da tarefa obrigatório");

				Tarefa? tarefaVerification = Buscar(x => x.Id == tarefa.Id);

				if (tarefaVerification == null)
					throw new Exception("Tarefa inexistente");

				if(tarefaVerification.EstadoTarefa != tarefa.EstadoTarefa)
					tarefaVerification.EstadoTarefa = tarefa.EstadoTarefa;



				Update(tarefaVerification);

				return tarefaVerification;
			}
			catch
			{
				throw;
			}
		}
	}
}

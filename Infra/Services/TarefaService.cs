using Infra.Entities;
using Infra.Interfaces;

namespace Infra.Services
{
    internal class TarefaService : BaseService<Tarefa>, ITarefaService
    {
		private readonly ITarefaRepository _tarefaRepository;

		private readonly IAzureBlobService _blobService;

		private readonly IUsuarioService _usuarioService;

		public TarefaService(ITarefaRepository repository, IAzureBlobService blobService, IUsuarioService usuarioService) : base(repository)
		{
			_tarefaRepository = repository;
			_blobService = blobService;
			_usuarioService = usuarioService;
		}

		public Tarefa? AddTarefa(Tarefa tarefa)
		{
			try
			{
				Usuario? usuarioVerification = _usuarioService.BuscarPorId(tarefa.UsuarioId);

				if (usuarioVerification == null)
					throw new Exception("Usuário não encontrado");

				if (!string.IsNullOrWhiteSpace(tarefa.Ficheiro))
					tarefa.Ficheiro = _blobService.FileUploadBase64(tarefa.Ficheiro);

				return Insert(tarefa);
			}
			catch
			{
				throw;
			}
		}

		public Tarefa AtualizarTarefa(Tarefa tarefa)
		{
			try
			{
				if (tarefa.Id == null)
					throw new Exception("Id da tarefa obrigatório");

				Tarefa? tarefaVerification = Buscar(x => x.Id == tarefa.Id);

				if (tarefaVerification == null)
					throw new Exception("Tarefa inexistente");

				if (!string.IsNullOrWhiteSpace(tarefa.Nome) && tarefa.Nome != tarefaVerification.Nome)
					tarefaVerification.Nome = tarefa.Nome;

				if (tarefaVerification.EstadoTarefa != tarefa.EstadoTarefa)
					tarefaVerification.EstadoTarefa = tarefa.EstadoTarefa;

				if (tarefa.DuracaoEstimada != tarefaVerification.DuracaoEstimada)
					tarefaVerification.DuracaoEstimada = tarefa.DuracaoEstimada;

				if (!string.IsNullOrWhiteSpace(tarefa.Ficheiro))
					tarefaVerification.Ficheiro = _blobService.FileUploadBase64(tarefa.Ficheiro);

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

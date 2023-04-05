using Infra.Entities;
using Infra.Entities.Enums;
using Infra.Interfaces;

namespace Infra.Services
{
    internal class TarefaService : BaseService<Tarefa>, ITarefaService
    {
		private readonly ITarefaRepository _tarefaRepository;

		private readonly IHistoricoTarefaService _historicoService;

		private readonly IAzureBlobService _blobService;

		private readonly IUsuarioService _usuarioService;

		public TarefaService(ITarefaRepository repository, IAzureBlobService blobService, IUsuarioService usuarioService, IHistoricoTarefaService historicoService) : base(repository)
		{
			_tarefaRepository = repository;
			_blobService = blobService;
			_usuarioService = usuarioService;
			_historicoService = historicoService;
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

				Insert(tarefa);

				HistoricoTarefa historico = new()
				{
					TarefaId = (int)tarefa.Id,
					UsuarioId = tarefa.UsuarioId,
					DataAgendamento = tarefa.DataAgendamento,
					DuracaoEstimada = tarefa.DuracaoEstimada,
					EstadoTarefa = tarefa.EstadoTarefa

				};

				_historicoService.Insert(historico);

				return tarefa;
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

				if (tarefa.Nome == null && tarefa.EstadoTarefa == null && tarefa.DuracaoEstimada == null && tarefa.DataAgendamento == null && tarefa.UsuarioId == null)
					throw new Exception("Preencha os dados obrigatório");

				Tarefa? tarefaVerification = Buscar(x => x.Id == tarefa.Id);

				if (tarefaVerification == null)
					throw new Exception("Tarefa inexistente");

				if (tarefaVerification.DataFinalizada != null)
					throw new Exception("Esta tarefa está finalizada, proibido alterar");

				if (!string.IsNullOrWhiteSpace(tarefa.Nome) && tarefa.Nome != tarefaVerification.Nome)
					tarefaVerification.Nome = tarefa.Nome;

				if (tarefaVerification.EstadoTarefa != tarefa.EstadoTarefa)
					tarefaVerification.EstadoTarefa = tarefa.EstadoTarefa;
				
				if (tarefaVerification.UsuarioId != tarefa.UsuarioId)
					tarefaVerification.UsuarioId = tarefa.UsuarioId;
				
				if (tarefaVerification.DataAgendamento != tarefa.DataAgendamento)
					tarefaVerification.DataAgendamento = tarefa.DataAgendamento;

				if (tarefaVerification.EstadoTarefa == EstadoTarefa.Finalizada)
					tarefaVerification.DataFinalizada = DateTime.Now;

				if (tarefa.DuracaoEstimada != tarefaVerification.DuracaoEstimada)
					tarefaVerification.DuracaoEstimada = tarefa.DuracaoEstimada;

				if (!string.IsNullOrWhiteSpace(tarefa.Ficheiro))
					tarefaVerification.Ficheiro = _blobService.FileUploadBase64(tarefa.Ficheiro);

				Update(tarefaVerification);

				HistoricoTarefa? historicoVerification = _historicoService.Buscar(x => x.TarefaId == tarefaVerification.Id);

				if (historicoVerification == null)
					throw new Exception("Esta tarefa não tem histórico");

				if (historicoVerification.DataFinalizada != null)
					throw new Exception("Esta tarefa está finalizada, proibido alterar");

				if (tarefaVerification.EstadoTarefa == EstadoTarefa.Agendada)
				{
					HistoricoTarefa historico = new()
					{
						TarefaId = (int)tarefaVerification.Id,
						UsuarioId = tarefaVerification.UsuarioId,
						DataAgendamento = tarefaVerification.DataAgendamento,
						DuracaoEstimada = tarefaVerification.DuracaoEstimada,
						EstadoTarefa = tarefaVerification.EstadoTarefa

					};

					_historicoService.Insert(historico);
				}
				else if (tarefaVerification.EstadoTarefa == EstadoTarefa.Andamento)
				{
					HistoricoTarefa historico = new()
					{
						TarefaId = (int)tarefaVerification.Id,
						UsuarioId = tarefaVerification.UsuarioId,
						DataAgendamento = tarefaVerification.DataAgendamento,
						DuracaoEstimada = tarefaVerification.DuracaoEstimada,
						EstadoTarefa = tarefaVerification.EstadoTarefa

					};

					_historicoService.Insert(historico);
				}
				else if (tarefaVerification.EstadoTarefa == EstadoTarefa.Finalizada)
				{
					HistoricoTarefa historico = new()
					{
						TarefaId = (int)tarefaVerification.Id,
						UsuarioId = tarefaVerification.UsuarioId,
						DataAgendamento = tarefaVerification.DataAgendamento,
						DataFinalizada = tarefaVerification.DataFinalizada,
						DuracaoEstimada = tarefaVerification.DuracaoEstimada,
						EstadoTarefa = tarefaVerification.EstadoTarefa
					};

					_historicoService.Insert(historico);
				}

				return tarefaVerification;
			}
			catch
			{
				throw;
			}
		}
	}
}

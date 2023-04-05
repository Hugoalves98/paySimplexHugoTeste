using AutoMapper;
using Infra.DTOs;
using Infra.Entities;
using Infra.Interfaces;
using MeuUsadoAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace paySimplexHugoTeste.Controllers
{
	/// <summary>Controller para gerenciar Tarefas</summary>
	/// <response code="200">O processamento ocorreu corretamente</response>
	/// <response code="400">Ocorreu um erro no processamento</response>
	/// <response code="401">Autorização do token inválido</response>
	/// <response code="420">Usuário ou senha inválido</response>
	/// <response code="500">Ocorreu um erro inesperado</response>
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status401Unauthorized)]
	[ProducesResponseType(420)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]
	[Route("api/[controller]")]
	[ApiController]

	public class TarefaController : BaseController
	{
		private readonly ITarefaService _tarefaService;

		public TarefaController(IMapper mapper, ITarefaService tarefaService) : base(mapper)
		{
			_tarefaService = tarefaService;
		}

		/// <summary>Cria uma nova tarefa</summary>
		/// <remarks>
		/// 
		///		Uso do Ficheiro:
		///     Para adicionar um ficheiro precisa transformar a imagem em base64, segue o site https://www.base64decode.org/
		///     Ou envie com string vazia "ficheiro": ""
		///     
		/// </remarks>
		/// <returns>Objeto result</returns>
		[ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
		[HttpPost("AddTarefa")]
		public IActionResult AddTarefa(TarefaInsertDTO tarefa)
		{
			try
			{
				Result result = new Result
				{
					Code = 1,
					Message = "Tarefa criada com sucesso",
					Obj = _tarefaService.AddTarefa(_mapper.Map<Tarefa>(tarefa))
				};

				return Ok(result);
			}
			catch (Exception ex)
			{
				Result result = new Result
				{
					Code = 0,
					Message = ex.Message
				};

				return BadRequest(result);
			}
		}

		/// <summary>Atualizar uma tarefa</summary>
		/// <remarks>
		/// 
		///    Necessário passar o ID da tarefa, pegar na resposta de quando criou-a ou no banco
		///    Necessário passar o ID do usuário responsável, a menos que deseje mudá-lo, pegar na resposta de quando criou-o ou no banco
		///    Necessário passar o mesmo nome da tarefa, a menos que deseje mudá-lo, pegar no resposta de quando criou-o ou no banco
		///    Necessário passar a duração estimada, a menos que deseje mudá-la, pegar na resposta de quando criou-a ou no banco
		///    Necessário manter a primeira DATA de agendamento da tarefa, a menos que deseje mudá-la,, pegar no resposta de quando criou-a ou no banco
		///    A data de finalizada será criada automaticamente quando for enviado o número 2 no EstadoTarefa
		///    
		/// </remarks>
		/// <returns>Objeto result</returns>
		[ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
		[HttpPost("AtualizarTarefa")]
		public IActionResult AtualizarTarefa(TarefaDTO tarefa)
		{
			try
			{
				Result result = new Result
				{
					Code = 1,
					Message = "Tarefa atualizada com sucesso.",
					Obj = _tarefaService.AtualizarTarefa(_mapper.Map<Tarefa>(tarefa))
				};

				return Ok(result);
			}
			catch (Exception ex)
			{
				Result result = new Result
				{
					Code = 0,
					Message = ex.Message
				};

				return BadRequest(result);
			}
		}

		/// <summary>Listar uma tarefa específica para consultar seu estado atual</summary>
		/// <remarks>
		/// 
		///    Necessário passar o ID da tarefa
		///    Nesse método é buscado a primeira vez que entrou andamento na tabela histórico e quando entrou finalizado, a partir dai é feito uma subtração entre a data de criação no banco de cada um para verificar quanto tempo a tarefa ficou em andamento, caso não tenha sido finalizada ainda, retornará a tarefa com seus dados atuais somente
		///    
		/// </remarks>
		/// <returns>Objeto result</returns>
		[ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
		[HttpGet("BuscarTarefaId")]
		public IActionResult ListarTarefaPorId(int tarefaId)
		{
			try
			{
				Result result = new Result
				{
					Code = 1,
					Message = "Busca realizada",
					Obj = _tarefaService.ListarTarefaPorId(tarefaId)
				};

				return Ok(result);
			}
			catch (Exception ex)
			{
				Result result = new Result
				{
					Code = 0,
					Message = ex.Message
				};

				return BadRequest(result);
			}
		}

		/// <summary>Listar todas as tarefas</summary>
		/// <remarks>
		///    
		/// </remarks>
		/// <returns>Objeto result</returns>
		[ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
		[HttpGet("ListarTarefas")]
		public IActionResult ListarTarefas()
		{
			try
			{
				Result result = new Result
				{
					Code = 1,
					Message = "Tarefas listadas com sucesso",
					Obj = _tarefaService.BuscarTodos(x => x.Deletado != true)
				};

				return Ok(result);
			}
			catch (Exception ex)
			{
				Result result = new Result
				{
					Code = 0,
					Message = ex.Message
				};

				return BadRequest(result);
			}
		}

		/// <summary>Listar todas as tarefas de um usuário</summary>
		/// <remarks>
		/// 
		///    Necessário passar o ID do usuário
		///    
		/// </remarks>
		/// <returns>Objeto result</returns>
		[ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
		[HttpGet("ListarTarefasPorUsuario")]
		public IActionResult ListarTarefasPorUsuario(int usuarioId)
		{
			try
			{
				Result result = new Result
				{
					Code = 1,
					Message = "Tarefa listada com sucesso",
					Obj = _tarefaService.BuscarTodos(x => x.UsuarioId == usuarioId)
				};

				return Ok(result);
			}
			catch (Exception ex)
			{
				Result result = new Result
				{
					Code = 0,
					Message = ex.Message
				};

				return BadRequest(result);
			}
		}
	}
}

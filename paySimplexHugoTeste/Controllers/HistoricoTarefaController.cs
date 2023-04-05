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

	public class HistoricoTarefaController : BaseController
	{
		private readonly IHistoricoTarefaService _histTarefaService;

		public HistoricoTarefaController(IMapper mapper, IHistoricoTarefaService histTarefaService) : base(mapper)
		{
			_histTarefaService = histTarefaService;
		}

		

		/// <summary>Listar uma tarefa específica para consultar seu ciclo de vida</summary>
		/// <remarks>
		/// 
		///    Necessário passar o ID da tarefa
		///    
		/// </remarks>
		/// <returns>Objeto result</returns>
		[ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
		[HttpGet("BuscarHistoricoTarefaId")]
		public IActionResult ListarTarefa(int tarefaId)
		{
			try
			{
				Result result = new Result
				{
					Code = 1,
					Message = "Busca realizada",
					Obj = _histTarefaService.BuscarTodos(x => x.TarefaId == tarefaId)
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
		[HttpGet("ListarHistricoTarefas")]
		public IActionResult ListarTarefas()
		{
			try
			{
				Result result = new Result
				{
					Code = 1,
					Message = "Histórico de Tarefas listado com sucesso",
					Obj = _histTarefaService.BuscarTodos(x => x.Deletado != true)
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
		[HttpGet("ListarHistoricoTarefasPorUsuario")]
		public IActionResult ListarTarefasPorUsuario(int usuarioId)
		{
			try
			{
				Result result = new Result
				{
					Code = 1,
					Message = "Tarefas listadas com sucesso",
					Obj = _histTarefaService.BuscarTodos(x => x.UsuarioId == usuarioId)
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

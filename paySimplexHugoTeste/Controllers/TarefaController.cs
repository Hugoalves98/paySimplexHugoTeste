using AutoMapper;
using Infra.DTOs;
using Infra.Entities;
using Infra.Interfaces;
using MeuUsadoAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace paySimplexHugoTeste.Controllers
{
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
					Obj = _tarefaService.Insert(_mapper.Map<Tarefa>(tarefa))
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

		//Necessário passar o ID da tarefa
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

		[ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
		[HttpGet("BuscarTarefaId")]
		public IActionResult ListarTarefa(int id)
		{
			try
			{
				Result result = new Result
				{
					Code = 1,
					Message = "Busca realizada",
					Obj = _tarefaService.BuscarPorId(id)
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

using AutoMapper;
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
		public IActionResult AddTarefa([FromBody] Tarefa tarefa)
		{
			try
			{
				Result result = new Result
				{
					Code = 1,
					Message = "Tarefa criada com sucesso",
					Obj = _tarefaService.Insert(tarefa)
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

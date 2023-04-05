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

	public class UsuarioController : BaseController
	{
		private readonly IUsuarioService _usuarioService;

		public UsuarioController(IMapper mapper, IUsuarioService usuarioService) : base(mapper)
		{
			_usuarioService = usuarioService;
		}

		[ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
		[HttpPost("AddUsuario")]
		public IActionResult AddUsuario([FromBody] UsuarioDTO usuario)
		{
			try
			{
				Result result = new Result
				{
					Code = 1,
					Message = "Usuario criado com sucesso",
					Obj = _usuarioService.Insert(_mapper.Map<Usuario>(usuario))
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

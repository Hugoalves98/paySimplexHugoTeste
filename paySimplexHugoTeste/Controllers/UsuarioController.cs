using AutoMapper;
using Infra.DTOs;
using Infra.Entities;
using Infra.Interfaces;
using MeuUsadoAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace paySimplexHugoTeste.Controllers
{
	/// <summary>Controller para gerenciar Usuários</summary>
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

	public class UsuarioController : BaseController
	{
		private readonly IUsuarioService _usuarioService;

		public UsuarioController(IMapper mapper, IUsuarioService usuarioService) : base(mapper)
		{
			_usuarioService = usuarioService;
		}

		/// <summary>Criar um usuário</summary>
		/// <remarks>
		///    
		/// </remarks>
		/// <returns>Objeto result</returns>
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

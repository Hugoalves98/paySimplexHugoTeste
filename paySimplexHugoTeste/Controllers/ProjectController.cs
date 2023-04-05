using AutoMapper;
using Infra.Entities;
using Infra.DTOs;
using Infra.Interfaces;
using Infra.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MeuUsadoAPI.Controllers
{
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(420)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : BaseController
    {
        private readonly IProjectService _projectService;

        public ProjectController(IMapper mapper, IProjectService projectService) : base(mapper)
        {
			_projectService = projectService;
        }

        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [HttpPost("AddProject")]
        public IActionResult AddProject([FromBody] ProjectDTO project)
        {
            try
            {
				Result result = new Result
				{
					Code = 1,
					Message = "Projeto criado com sucesso",
					Obj = _projectService.AddProject(_mapper.Map<Project>(project))
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

		//[ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
		//[AllowAnonymous]
		//[HttpDelete("DeleteEmployee")]
		//public IActionResult DeleteEmployee([FromBody] EmployeeDTO deleteEmployee)
		//{
		//	try
		//	{
		//		deleteEmployee = _mapper.Map<EmployeeDTO>(_empService.DeleteEmployee(_mapper.Map<EmployeeDTO>(deleteEmployee)));

		//		Result result = new Result
		//		{
		//			Code = 1,
		//			Message = "Funcionário apagado com sucesso.",
		//			Obj = deleteEmployee
		//	    };

		//		return Ok(result);
		//	}
		//	catch (Exception ex)
		//	{
		//		Result result = new Result
		//		{
		//			Code = 0,
		//			Message = ex.Message
		//		};

		//		return BadRequest(result);
		//	}
		//}
	}
}

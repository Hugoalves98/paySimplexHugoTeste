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
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _empService;

        public EmployeeController(IMapper mapper, IEmployeeService empService) : base(mapper)
        {
			_empService = empService;
        }

        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee([FromBody] EmployeeDTO employee)
        {
            try
            {
				Result result = new Result
				{
					Code = 1,
					Message = "Funcionário criado com sucesso",
					Obj = _empService.AddEmployee(_mapper.Map<Employee>(employee))
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
        [HttpGet("GetEmployee")]
        public IActionResult GetEmployee([FromQuery] int employeeId)
        {
            try
            {
                Result result = new Result
                {
                    Code = 1,
                    Message = "Funcionário listado com sucesso",
                    Obj = _empService.GetEmployee(employeeId)
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

		[ProducesResponseType(typeof(IQueryable<Employee>), StatusCodes.Status200OK)]
		[HttpGet("ListEmployees")]
		public async Task<IActionResult> ListEmployees()
		{
			try
			{
				List<Employee> retornoEmployees = await _empService.ListEmployees();

				return Ok(retornoEmployees);
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
		[AllowAnonymous]
		[HttpDelete("DeleteEmployee")]
		public IActionResult DeleteEmployee([FromBody] EmployeeDTO deleteEmployee)
		{
			try
			{
				deleteEmployee = _mapper.Map<EmployeeDTO>(_empService.DeleteEmployee(_mapper.Map<EmployeeDTO>(deleteEmployee)));

				Result result = new Result
				{
					Code = 1,
					Message = "Funcionário apagado com sucesso.",
					Obj = deleteEmployee
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

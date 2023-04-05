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
    public class MeetingController : BaseController
    {
        private readonly IMeetingService _meetingService;

        public MeetingController(IMapper mapper, IMeetingService meetingService) : base(mapper)
        {
			_meetingService = meetingService;
        }

        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [HttpPost("AddMeeting")]
        public IActionResult AddMeeting([FromBody] MeetingDTO meeting)
        {
            try
            {
				Result result = new Result
				{
					Code = 1,
					Message = "Meeting criada com sucesso",
					Obj = _meetingService.AddMeeting(_mapper.Map<Meeting>(meeting))
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

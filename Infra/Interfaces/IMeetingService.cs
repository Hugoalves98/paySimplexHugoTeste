using Infra.DTOs;
using Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IMeetingService : IBaseService<Meeting>
    {
		Meeting? AddMeeting(Meeting meeting);

		//Employee? DeleteEmployee(EmployeeDTO deleteEmployee);

		//User? CreateUser(User user);

		//User? UpdatePhotoUser(PhotoProfileDTO user);

		//LoginReturnDTO? LoginUser(string email, string password);



		//List<UserHome> GetUsersHome(int userId);
	}
}

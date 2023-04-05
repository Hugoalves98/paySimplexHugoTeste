
using Infra.DTOs;
using Infra.Entities;

namespace Infra.Interfaces
{
    public interface IMeetingRepository : IRepository<Meeting>
    {
		Meeting? AddMeeting(Meeting meeting);

		//Employee? DeleteEmployee(EmployeeDTO deleteEmployee);

		//public List<UserHome> GetUserHomes(int userId);

		//User? UpdatePhotoUser(PhotoProfileDTO user);
	}
}


using Infra.DTOs;
using Infra.Entities;

namespace Infra.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
		Project? AddProject(Project project);

		//Employee? DeleteEmployee(EmployeeDTO deleteEmployee);

		//public List<UserHome> GetUserHomes(int userId);

		//User? UpdatePhotoUser(PhotoProfileDTO user);
	}
}

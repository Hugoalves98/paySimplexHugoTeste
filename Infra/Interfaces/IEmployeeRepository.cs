
using Infra.DTOs;
using Infra.Entities;

namespace Infra.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
		Employee? AddEmployee(Employee employee);

		Employee? GetEmployee(int employeeId);

		Task<List<Employee>> ListEmployees();

		Employee? DeleteEmployee(EmployeeDTO deleteEmployee);

		//public List<UserHome> GetUserHomes(int userId);

		//User? UpdatePhotoUser(PhotoProfileDTO user);
	}
}

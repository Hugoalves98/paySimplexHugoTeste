using Infra.Data;
using Infra.DTOs;
using Infra.Entities;
using Infra.Interfaces;
using Infra.Repositories;
using Infra.Services;

namespace Infra.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(Context context) : base(context)
        {
        }

		//public Employee? AddEmployee(Employee employee) => Create(employee);

		public Employee? AddEmployee(Employee employee)
		{
		    try
		    {
				employee.Email = employee.Email?.ToUpper();
		        employee.Nome = employee.Nome?.ToUpper();

				Employee? employeeVerification = Find(x => x.Email == employee.Email);

		        if (employeeVerification != null)
		            throw new Exception("Email já cadastrado");

		        return Create(employee);
		    }
		    catch
		    {
		        throw;
		    }
		}
		
		public Employee? GetEmployee(int employeeId)
		{
		    try
		    {
				Employee? employee = Find(x => x.Id == employeeId);

		        if (employee == null)
		            throw new Exception("Funcionário não cadastrado");

		        return employee;
		    }
		    catch
		    {
		        throw;
		    }
		}

		public async Task<List<Employee>> ListEmployees()
		{
			try
			{
				IQueryable<Employee> query = ObterQueryable();

				return await Task.FromResult(query.Distinct().ToList());
			}
			catch (Exception ex)
			{
				throw ;
			}
		}

		public Employee? DeleteEmployee(EmployeeDTO deleteEmployee)
		{
			try
			{
				Employee? delEmployee = Find(x => x.Email == deleteEmployee.Email.ToUpper() && x.Nome == deleteEmployee.Nome);

				if (delEmployee == null)
					throw new Exception("Código incorreto, por favor, verifique se o Nome e Email estão corretos!");

				Delete(delEmployee);

				return delEmployee;
			}
			catch (Exception)
			{
				_context.Dispose();

				throw;
			}
		}

		//      public List<UserHome> GetUserHomes(int userId)
		//      {
		//          try
		//          {
		//              List<UserHome> retorno = (from user in _context.Users
		//                             join address in _context.Addresses on user.Id equals address.UserId
		//                             join rate in _context.RateUsers on user.Id equals rate.UserId
		//                             join sp in _context.serviceProviders on user.Id equals sp.UserId
		//                             where user.Id != userId && sp.Status == Enums.Enums.StatusProvider.Approved
		//                             select
		//                               new UserHome
		//                               {
		//                                   Name = user.Name,
		//                                   LastName = user.LastName,
		//                                   City = address.City,
		//                                   Email = user.Email,
		//                                   State = address.UF,
		//                                   Stars = rate.Stars,
		//                                   Id = user.Id.Value,
		//                                   Tel = user.Tel
		//                               }).Distinct().ToList();

		//              return retorno;
		//          }
		//          catch (Exception)
		//          {
		//              throw;
		//          }
		//      }

		//public User? UpdatePhotoUser(PhotoProfileDTO user)
		//{
		//	try
		//	{
		//		User? userVerification = Find(x => x.Id == user.Id);

		//              if(userVerification == null)
		//			throw new Exception("Usuario não encontrado");

		//		if (!string.IsNullOrWhiteSpace(user.PhotoProfile))
		//			userVerification.PhotoProfile = new AzureBlobService().FileUploadBase64(user.PhotoProfile, "fotoperfil");

		//              userVerification.UpdateDate = DateTime.Now;

		//              Update(userVerification);

		//		return userVerification;
		//	}
		//	catch
		//	{
		//		throw;
		//	}
		//}
	}
}

using Infra.Data;
using Infra.DTOs;
using Infra.Entities;
using Infra.Interfaces;
using Infra.Repositories;
using Infra.Services;

namespace Infra.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(Context context) : base(context)
        {
        }

		//public Employee? AddEmployee(Employee employee) => Create(employee);

		public Project? AddProject(Project project)
		{
		    try
		    {
				project.Projeto = project.Projeto?.ToUpper();

				Project? projectVerification = Find(x => x.Projeto == project.Projeto);

		        if (projectVerification != null)
		            throw new Exception("Projeto já cadastrado");

		        return Create(project);
		    }
		    catch
		    {
		        throw;
		    }
		}

		//public Employee? DeleteEmployee(EmployeeDTO deleteEmployee)
		//{
		//	try
		//	{
		//		Employee? delEmployee = Find(x => x.Email == deleteEmployee.Email.ToUpper() && x.Nome == deleteEmployee.Nome);

		//		if (delEmployee == null)
		//			throw new Exception("Código incorreto, por favor, verifique se o Nome e Email estão corretos!");

		//		Delete(delEmployee);

		//		return delEmployee;
		//	}
		//	catch (Exception)
		//	{
		//		_context.Dispose();

		//		throw;
		//	}
		//}

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

using Infra.DTOs;
using Infra.Entities;
using Infra.Interfaces;
using System;

namespace Infra.Services
{
    public class ProjectService : BaseService<Project>, IProjectService
    {

        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository) : base(projectRepository)
        {
			_projectRepository = projectRepository;
        }

		public Project? AddProject(Project project) => _projectRepository.AddProject(project);

		//public Employee? DeleteEmployee(EmployeeDTO employee) => _employeeRepository.DeleteEmployee(employee);


		//public User? CreateUser(User user)
		//{
		//    try
		//    {
		//        user.Email = user.Email?.ToUpper();
		//        user.Name = user.Name?.ToUpper();
		//        user.LastName = user.LastName?.ToUpper();

		//        if (string.IsNullOrEmpty(user.Password))
		//            throw new Exception("Digite sua senha, por favor!");

		//        if (user.Password != user.ConfirmPassword)
		//            throw new Exception("Confirmação de senha diferente de senha!");

		//        User? userVerification = Find(x => x.Email == user.Email);

		//        if (userVerification != null)
		//            throw new Exception("Email já cadastrado");

		//        user.Password = new Cryptography().CryptographStringy(user.Password);

		//        return Insert(user);
		//    }
		//    catch
		//    {
		//        throw;
		//    }
		//}

		//public LoginReturnDTO? LoginUser(string email, string password)
		//{
		//    try
		//    {
		//        User? user = Find(user => user.Email == email.ToUpper() && user.Password == new Cryptography().CryptographStringy(password));

		//        if (user == null)
		//            throw new Exception("Email ou Senha Incorreta");


		//        Address? address = _addressService.Find(x => x.UserId == user.Id);

		//        LoginReturnDTO loginReturn = new()
		//        {
		//            UserId = user.Id.Value,
		//            City = address != null ? address.City : "",
		//            Email = user.Email,
		//            Name = user.Name,
		//            LastName = user.LastName,
		//            Tel = user.Tel,
		//            UF = address != null ? address.UF : "",
		//            ProfilePhoto = user.PhotoProfile
		//        };

		//        loginReturn.Token = GenerateToken.GenToken(user);

		//        return loginReturn;
		//    }
		//    catch (Exception)
		//    {
		//        throw;
		//    }
		//}



		//public Employee? InsertEmployee(Address address) => _addressService.Insert(address);

		//public List<UserHome> GetUsersHome(int userId) => _userRepository.GetUserHomes(userId);
	}
}

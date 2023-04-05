using Infra.Entities;
using System.ComponentModel.DataAnnotations;

namespace Infra.DTOs
{
    public class ProjectDTO
    {
		public string? Gerente { get; set; }

		public string? Projeto { get; set; }

		public string? ClienteResponsavel { get; set; }

		public string? Nome { get; set; }

		public string? Duracao { get; set; }

		public string? Sprint { get; set; }

		public DateTime? Inicio { get; set; }

		public DateTime? Termino { get; set; }

		public void SetEmployeeName(Employee employee)
		{
			Nome = employee.Nome;
		}
	}
}

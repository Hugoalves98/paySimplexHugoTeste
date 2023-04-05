using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Entities
{
    public class Project : BaseEntity 
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

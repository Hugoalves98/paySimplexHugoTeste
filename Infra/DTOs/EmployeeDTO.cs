using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DTOs
{
    public class EmployeeDTO
	{
		public string? Email { get; set; }

		public string? Nome { get; set; }

		public string? Cargo { get; set; }

		public string? Stack { get; set; }

		public string? Avaliacao { get; set; }

		public int? Idade { get; set; }

		public DateTime? Entrada { get; set; }

		public DateTime? Saida { get; set; }

		public string? MotivoSaida { get; set; }
	}
}

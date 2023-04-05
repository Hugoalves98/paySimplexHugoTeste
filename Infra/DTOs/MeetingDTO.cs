using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Entities;

namespace Infra.DTOs
{
    public class MeetingDTO 
    {
		public string? Projeto { get; set; }

		public string? Participantes { get; set; }

		public string? Comparecimento { get; set; }

		public string? Duracao { get; set; }

		public string? Sprint { get; set; }

		public string? Descricao { get; set; }

		public DateTime? Ocorrido { get; set; } = DateTime.Now;
	}
}

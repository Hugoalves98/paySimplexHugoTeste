using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Entities
{
    public class Meeting : BaseEntity 
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

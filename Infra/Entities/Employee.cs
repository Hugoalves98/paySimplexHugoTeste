using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Entities
{
    public class Employee : BaseEntity 
    {
        public string? Email { get; set; }

        public string? Nome { get; set; }
        
        public string? Cargo { get; set; }

        public string? Stack { get; set; }

        //public string? Formacao { get; set; }

        //public string? Estudando { get; set; }

        //public string? Avaliacao { get; set; }

        //public string? Reside { get; set; }

        public int? Idade { get; set; }

		//public DateTime? Nascimento { get; set; }

		public DateTime? Entrada { get; set; }

        public DateTime? Saida { get; set; }

        public string? MotivoSaida { get; set; }
	}
}

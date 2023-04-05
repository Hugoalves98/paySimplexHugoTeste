using Infra.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Entities
{
    public class HistoricoTarefa : BaseEntity
    {
		[Required]
		[ForeignKey("TarefaId")]
		public int TarefaId { get; set; }

		public virtual Tarefa? Tarefa { get; set; }

		[Required]
        public DateTime? DataAgendamento { get; set; } 

		public DateTime? DataFinalizada { get; set; } 

        [Required]
        public double DuracaoEstimada { get; set; } 

        [Required]
        public EstadoTarefa EstadoTarefa { get; set; }

		[Required]
		[ForeignKey("UsuarioId")]
		public int UsuarioId { get; set; }

		public virtual Usuario? Usuario { get; set; }
	}
}

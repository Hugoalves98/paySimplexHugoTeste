using Infra.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Entities
{
    public class Tarefa : BaseEntity
    {
        [Required]
        public string? Nome { get; set; }

		public string? Ficheiro { get; set; }

		[Required]
        public DateTime? DataAgendamento { get; set; } 

		[Required]
		public DateTime? DataFinalizacao { get; set; } 

        [Required]
        public string DuracaoEstimada { get; set; } = string.Empty;

        [Required]
        public EstadoTarefa EstadoTarefa { get; set; } = 0;

		[Required]
		[ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

        public virtual Usuario? Usuario { get; set;}
    }
}

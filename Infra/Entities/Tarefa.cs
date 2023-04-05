using Infra.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Entities
{
    public class Tarefa : BaseEntity
    {
        [Required]
        public string? Nome { get; set; }

        [Required]
        public DateTime? DataAgendamento { get; set; } = default(DateTime?);

        [Required]
        public string DuracaoEstimada { get; set; } = string.Empty;

        [Required]
        public EstadoTarefa EstadoTarefa { get; set; } = 0;
    }
}

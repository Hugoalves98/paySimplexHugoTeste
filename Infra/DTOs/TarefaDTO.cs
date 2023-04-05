using Infra.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DTOs
{
    public class TarefaDTO
    {
        public int? Id { get; set; } = null;

        public int? UsuarioId { get; set; } = null;

        [Required]
        public string? Nome { get; set; }

        [Required]
        public DateTime? DataAgendamento { get; set; } 

        [Required]
        public double DuracaoEstimada { get; set; } 

        [Required]
        public EstadoTarefa EstadoTarefa { get; set; } = 0;
    }
}

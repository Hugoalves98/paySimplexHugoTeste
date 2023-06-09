﻿using Infra.Entities.Enums;
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

		public DateTime? DataFinalizada { get; set; } 

        [Required]
        public double DuracaoEstimada { get; set; } 

        [Required]
        public EstadoTarefa EstadoTarefa { get; set; } = 0;

		[Required]
		[ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

        public virtual Usuario? Usuario { get; set;}
    }
}

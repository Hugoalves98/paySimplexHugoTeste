﻿using Infra.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DTOs
{
    public class TarefaInsertDTO
    {
        [Required]
        public int? UsuarioId { get; set; } = null;

		public string? Ficheiro { get; set; }

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

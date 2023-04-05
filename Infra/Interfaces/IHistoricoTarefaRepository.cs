﻿using Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IHistoricoTarefaRepository : IRepository<HistoricoTarefa>
    {
		public HistoricoTarefa? BuscaUltimaTarefaPorId(int tarefaId);

	}
}

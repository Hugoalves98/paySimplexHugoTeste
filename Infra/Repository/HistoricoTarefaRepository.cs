using Infra.Data;
using Infra.Entities;
using Infra.Interfaces;
using Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class HistoricoTarefaRepository : Repository<HistoricoTarefa>, IHistoricoTarefaRepository
    {
        public HistoricoTarefaRepository(Context context) : base(context)
        {
        }

		public HistoricoTarefa? BuscaUltimaTarefaPorId(int tarefaId)
		{
			try
			{
				return _context.HistoricoTarefas.Where(x => x.TarefaId == tarefaId && x.DataCriacao == _context.HistoricoTarefas.Max(x => x.DataCriacao)).FirstOrDefault();
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}

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
    public class TarefaRepository : Repository<TarefaDTO>, ITarefaRepository
    {
        public TarefaRepository(Context context) : base(context)
        {
        }
    }
}

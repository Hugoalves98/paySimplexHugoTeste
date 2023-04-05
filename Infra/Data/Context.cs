using Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

		public DbSet<Tarefa> Tarefas { get; set; }

		public DbSet<Usuario> Usuarios { get; set; }

		public DbSet<HistoricoTarefa> HistoricoTarefas { get; set; }
	}
}

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
	}
}

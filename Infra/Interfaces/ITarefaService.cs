﻿using Infra.Entities;

namespace Infra.Interfaces
{
    public interface ITarefaService : IBaseService<Tarefa>
    {
		public Tarefa? AddTarefa(Tarefa tarefa);

		public Tarefa AtualizarTarefa(Tarefa tarefa);

		public object ListarTarefaPorId(int tarefaId);
	}
}

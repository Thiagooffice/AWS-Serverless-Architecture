﻿using ECommerceLambda.Domain.Models;

namespace ECommerceLambda.Repositories
{
    public interface IClienteRepository
    {
        Task Adicionar(Cliente cliente);
        Task Atualizar(Cliente cliente);
        Task<Cliente?> Buscar(string documento);
        Task Deletar(string documento);
    }
}

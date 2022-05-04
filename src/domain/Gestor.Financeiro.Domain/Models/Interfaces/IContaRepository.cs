using Gestor.Financeiro.Core.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Financeiro.Domain.Models.Interfaces
{
    public interface IContaRepository: IRepository<Conta>
    {
        Task<ActionResult<IEnumerable<Conta>>> ObterTodos();
        Task<ActionResult<Conta>> ObterPorId(Guid id);
        Task<int> CadastrarConta(Conta conta);
        Task<int> AtualizarConta(Guid id, Conta conta);
        Task<Conta> DesativarConta(Guid id,bool status);
        
    }
}

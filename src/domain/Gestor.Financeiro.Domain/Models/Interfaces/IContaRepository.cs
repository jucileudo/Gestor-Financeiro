using Gestor.Financeiro.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Financeiro.Domain.Models.Interfaces
{
    public interface IContaRepository: IRepository<Conta>
    {
        Task<IEnumerable<Conta>> ObterTodos();
        Task<Conta> ObterPorId(Guid id);
        Task<bool> CadastrarConta(Conta conta);
        Task<bool> AtualizarConta(Guid id, Conta conta);
        Task<Conta> DesativarConta(Guid id,bool status);
        
    }
}

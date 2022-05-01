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
        Task<IEnumerable<Transacao>> ObterTodos();
        Task<Transacao> ObterPorId(Guid id);
        Task<Transacao> CadastrarTrnasacao(Transacao transacao);
        Task<Transacao> AtualizarTransacao(Guid id, Transacao transacao);
    }
}

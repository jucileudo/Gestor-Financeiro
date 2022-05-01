using Gestor.Financeiro.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Financeiro.Domain.Models.Interfaces
{
    public interface ITransacaoRepository : IRepository<Transacao>
    {
        Task<IEnumerable<Transacao>> ObterTodos();
        Task<Transacao> ObterPorId(Guid id);
        Task<bool> CadastrarTransacao(Transacao transacao);
        Task<Transacao> AtualizarTransacao(Guid id, Transacao transacao);

        Task<IEnumerable<Transacao>> ObterPorCategoria(Guid id);


    }
}

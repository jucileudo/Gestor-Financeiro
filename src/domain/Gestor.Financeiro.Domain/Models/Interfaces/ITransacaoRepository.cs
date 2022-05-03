using Gestor.Financeiro.Core.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Financeiro.Domain.Models.Interfaces
{
    public interface ITransacaoRepository : IRepository<Transacao>
    {
        Task<ActionResult<IEnumerable<Transacao>>> ObterTodos();
        Task<ActionResult<Transacao>> ObterPorId(Guid id);
        void CadastrarTransacao(Transacao transacao);
        void AtualizarTransacao(Guid id, Transacao transacao);

        Task<IEnumerable<Transacao>> ObterPorCategoria(Guid id);


    }
}

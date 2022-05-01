using Gestor.Financeiro.Data.Context;
using Gestor.Financeiro.Domain.Models;
using Gestor.Financeiro.Domain.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systhem.Shop.Core.Data;

namespace Gestor.Financeiro.Data.Repository
{
    public class TransacaoRepository : ITransacaoRepository
    {

        private readonly FinanceiroContext _context;


        public TransacaoRepository(FinanceiroContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Transacao>> ObterTodos()
        {
            return await _context.Transacoes.ToListAsync();
        }

        public async Task<Transacao> ObterPorId(Guid id)
        {
            return await _context.Transacoes.FindAsync();
        }

        public async Task<IEnumerable<Transacao>> ObterPorCategoria(Guid id)
        {
            return await _context.Transacoes.Where(x => x.ContaId == id).ToListAsync();
        }

        public async Task<bool> CadastrarTransacao(Transacao transacao)
        {
            await _context.Transacoes.AddAsync(transacao);
            var result = Task.CompletedTask;
            return result.IsCompletedSuccessfully;

        }

        public async Task<Transacao> AtualizarTransacao(Guid id, Transacao transacao)
        {
            var transacaoBanco = await _context.Transacoes.FindAsync(id);
            transacaoBanco = transacao;
            await _context.Transacoes.AddAsync(transacaoBanco);
            var result = Task.CompletedTask;
            if (result.IsCompletedSuccessfully)
            {
                return transacaoBanco;

            }
            else
            {
                return null;
            }
        }


        public void Dispose()
        {
           _context?.Dispose();
        }

    }
}

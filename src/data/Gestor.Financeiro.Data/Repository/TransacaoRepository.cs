using Gestor.Financeiro.Data.Context;
using Gestor.Financeiro.Domain.Models;
using Gestor.Financeiro.Domain.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Financeiro.Data.Repository
{
    public class TransacaoRepository : ITransacaoRepository
    {

        private readonly FinanceiroContext _context;


        public TransacaoRepository(FinanceiroContext context)
        {
            _context = context;
        }

       

        public async Task<ActionResult<IEnumerable<Transacao>>> ObterTodos()
        {
            return await _context.Transacoes.Include(t => t.Conta).ToListAsync();
        }

        public async Task<ActionResult<Transacao>> ObterPorId(Guid id)
        {
            var transacao = await _context.Transacoes.FindAsync(id);
            var conta = await _context.Contas.FindAsync(transacao.ContaId);

            transacao.Conta = conta;
            return transacao;

        }

        public async Task<IEnumerable<Transacao>> ObterPorCategoria(Guid id)
        {
            return await _context.Transacoes.Where(x => x.ContaId == id).ToListAsync();
        }

        public async void CadastrarTransacao(Transacao transacao)
        {
             await _context.Transacoes.AddAsync(transacao);
            await _context.SaveChangesAsync();

        }

        public async void AtualizarTransacao(Guid id, Transacao transacao)
        {
            var transacaoBanco = await _context.Transacoes.FindAsync(id);
            transacaoBanco = transacao;
            _context.Entry(transacao).State = EntityState.Modified;

        }


        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}

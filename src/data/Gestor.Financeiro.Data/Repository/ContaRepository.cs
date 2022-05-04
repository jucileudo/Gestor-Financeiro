using Gestor.Financeiro.Core.CommonsObjects;
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
    public class ContaRepository : IContaRepository
    {
        private readonly FinanceiroContext _context;

        public ContaRepository(FinanceiroContext? context)
        {
            _context = context;
        }


        public async Task<ActionResult<IEnumerable<Conta>>> ObterTodos()
        {
            return await _context.Contas.ToListAsync();
        }
        public async Task<ActionResult<Conta>> ObterPorId(Guid id)
        {
            return await _context.Contas.FindAsync(id);
        }
        public async Task<int> CadastrarConta(Conta conta)
        {
            var id = Guid.NewGuid();
            conta.Id  = id;
            _context.Contas.Add(conta);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<int> AtualizarConta(Guid id, Conta conta)
        {
            var contaBanco = _context.Contas.Find(id);
            contaBanco = conta;
            _context.Entry(contaBanco).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            return result;

        }

        public async Task<Conta> DesativarConta(Guid id, bool status)
        {
            var conta = await _context.Contas.FindAsync(id);
            conta.Ativo = status;
            _context.Contas.Update(conta);
            await _context.SaveChangesAsync();
            return conta;
        }




    }
}

using Gestor.Financeiro.Core.CommonsObjects;
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
    public class ContaRepository : IContaRepository
    {
        private readonly FinanceiroContext _context;

        public ContaRepository(FinanceiroContext? context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Conta>> ObterTodos()
        {
            return await _context.Contas.ToListAsync();
        }
        public async Task<Conta> ObterPorId(Guid id)
        {
            return await _context.Contas.FindAsync(id);
        }
        public async Task<bool> CadastrarConta(Conta conta)
        {
            _context.AddAsync(conta);
            await _context.SaveChangesAsync();
            var result = Task.CompletedTask;
            return result.IsCompletedSuccessfully;


        }

        public async Task<bool> AtualizarConta(Guid id, Conta conta)
        {
            var contaBanco = _context.Contas.Find(id);
            contaBanco = conta;
            _context.Contas.Update(contaBanco);
            var result = Task.CompletedTask;
            return result.IsCompletedSuccessfully;
        }



        public async Task<Conta> DesativarConta(Guid id, bool status)
        {

            var contaBanco = await _context.Contas.FindAsync(id);
            contaBanco.Ativo = status;
            _context.Contas.Add(contaBanco);
            return contaBanco;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

       
    }
}

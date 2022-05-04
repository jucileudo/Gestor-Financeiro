#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gestor.Financeiro.Data.Context;
using Gestor.Financeiro.Domain.Models;
using Gestor.Financeiro.Domain.Models.Interfaces;
using Gestor.Financeiro.Core.Controllers;
using Gestor.Financeiro.Core.CommonsObjects;

namespace Gestor.Financeiro.Web.Api.Controllers
{
    [Route("api/[controller]")]

    public class ContasController : MainController
    {
        private readonly IContaRepository _contaRepository;

        public ContasController(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }


        [HttpGet("/listarContas")]
        public async Task<ActionResult<IEnumerable<Conta>>> GetContas()
        {
            return await _contaRepository.ObterTodos();
        }


        [HttpGet("/listarConta/{id}")]
        public async Task<ActionResult<Conta>> GetConta(Guid id)
        {
            var conta = await _contaRepository.ObterPorId(id);

            if (conta == null)
            {
                return CustomResponse(conta);
            }

            return Ok(conta);
        }


        [HttpPut("/atualizar/{id}")]
        public async Task<IActionResult> PutConta(Guid id, Conta conta)
        {
            if (id != conta.Id)
            {
                return CustomResponse(conta);
            }


            try
            {
                var result = await _contaRepository.AtualizarConta(id, conta);
                if (result > 0) return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                
                    throw new DomainException("Erro ao efetuar o procesamento! Tente novamente mais tarde");
                
            }

            return NoContent();
        }

       
        [HttpPost("/cadastrarConta")]
        public async Task<ActionResult<Conta>> PostConta(Conta conta)
        {
            if(!ModelState.IsValid) return CustomResponse(conta);

            try
            {
                var result = await _contaRepository.CadastrarConta( conta);
                if (result > 0) return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DomainException("Erro ao efetuar o procesamento! Tente novamente mais tarde");                
            }

            return NoContent();
        }

        // DELETE: api/Contas/5
        [HttpPut("/destivar/{id}")]
        public async Task<IActionResult> DesativarConta(Guid id,bool status)
        {
            


            try
            {
                var result = await _contaRepository.DesativarConta(id, status);
                 return Ok(result);
            }
            catch (DbUpdateConcurrencyException)
            {
                
                    throw new DomainException("Erro ao efetuar o procesamento! Tente novamente mais tarde");
                
            }

            return NoContent(); 
        }

        
    }
}

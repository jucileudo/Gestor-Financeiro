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
using Gestor.Financeiro.Core.Controllers;
using Gestor.Financeiro.Domain.Models.Interfaces;
using AutoMapper;

namespace Gestor.Financeiro.Web.Api.Controllers
{
    [Route("api/[controller]")]

    public class TransacaosController : MainController
    {
        private readonly ITransacaoRepository _transacaorepository;
        private readonly IMapper _mapper;

        public TransacaosController(ITransacaoRepository transacaorepository, IMapper mapper)
        {
            _transacaorepository = transacaorepository;
            _mapper = mapper;
        }



       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transacao>>> ObterTodas()
        {
            return await _transacaorepository.ObterTodos();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Transacao>> ObterPorId(Guid id)
        {
            var transacao = await _transacaorepository.ObterPorId(id);

            if (transacao == null)
            {
                return NotFound();
            }

            return transacao;
        }


        [HttpPut("/AtualizarTransacao/{id}")]
        public async Task<IActionResult> AtualizarTransacao(Guid id, Transacao transacao)
        {
            if (id != transacao.Id)
            {
                return CustomResponse(id);
            }


            _transacaorepository.AtualizarTransacao(id, transacao);

           return Ok();


        }
       
        [HttpPost("/CasdastrarTransacao")]
        public async Task<ActionResult<Transacao>> CadastrarTransacao(Transacao transacao)
        {
            if(!ModelState.IsValid) return  CustomResponse(transacao);


            var id =  Guid.NewGuid();
             transacao.Id = id;
             _transacaorepository.CadastrarTransacao(transacao);
          

            return  Ok();
        }

    }
}

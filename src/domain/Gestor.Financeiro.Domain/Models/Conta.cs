using Gestor.Financeiro.Core.CommonsObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Financeiro.Domain.Models
{
    public class Conta : Entity, IEntityRoot
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        //public IEnumerable<Transacao>? Transacoes { get; } = new List<Transacao>();

    }
}

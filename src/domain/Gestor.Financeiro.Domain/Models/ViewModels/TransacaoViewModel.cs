using Gestor.Financeiro.Core.CommonsObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Financeiro.Domain.Models.ViewModels
{
    public class TransacaoViewModel : Entity, IEntityRoot
    {
        public string? Titulo { get; set; }     
        public int valor { get; set; }
        public string? Tipo { get; set; }      
        public DateTime DataCriacao { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool Quitado { get; set; }      
        public Guid ContaId { get; set; }

     
    }
}

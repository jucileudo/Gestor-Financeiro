using Gestor.Financeiro.Core.CommonsObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Financeiro.Domain.Models
{
    public class Transacao :Entity, IEntityRoot
    {
        [Required(ErrorMessage = "Campo {0} preenchimento obrigatório!")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Quantidade de caracteres insuficiente")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "Campo {0} preenchimento obrigatório!")]
        [Range(0, int.MaxValue, ErrorMessage = "Informações inválidas")]
        public int valor { get; set; }
        [Required(ErrorMessage = "Campo {0} preenchimento obrigatório!")]

        public string? Tipo { get; set; }

        [Required(ErrorMessage = "Campo {0} preenchimento obrigatório!")]


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataCriacao { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataVencimento { get; set; }
        public bool Quitado { get; set; }

        [ForeignKey("Categoria")]
        [Column(Order = 1)]
        public Guid ContaId { get; set; }

        public virtual Conta? Conta { get; set; }
    }
}

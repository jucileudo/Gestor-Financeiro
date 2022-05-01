using Gestor.Financeiro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Financeiro.Data.Mapping
{
    public class TransacaoMapping : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("Trasacao");
            builder.HasKey(t => t.Id);
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Titulo)
               .IsRequired()
               .HasColumnType("varchar(250)");
            builder.Property(c => c.Tipo)
              .IsRequired()
              .HasColumnType("varchar(250)");
            builder.Navigation(c => c.Conta).AutoInclude();

           
        }
    }
}

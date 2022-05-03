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
    public class ContaMapping : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("Conta");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome)
               .IsRequired()
               .HasColumnType("varchar(250)");
          

          
        }
    }
}

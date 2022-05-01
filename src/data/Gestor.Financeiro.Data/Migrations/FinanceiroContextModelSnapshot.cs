﻿// <auto-generated />
using System;
using Gestor.Financeiro.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gestor.Financeiro.Data.Migrations
{
    [DbContext(typeof(FinanceiroContext))]
    partial class FinanceiroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Gestor.Financeiro.Domain.Models.Conta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("Gestor.Financeiro.Domain.Models.Transacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ContaId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Quitado")
                        .HasColumnType("boolean");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("valor")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ContaId");

                    b.ToTable("Transacoes");
                });

            modelBuilder.Entity("Gestor.Financeiro.Domain.Models.Transacao", b =>
                {
                    b.HasOne("Gestor.Financeiro.Domain.Models.Conta", "Conta")
                        .WithMany("Transacoes")
                        .HasForeignKey("ContaId")
                        .IsRequired();

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("Gestor.Financeiro.Domain.Models.Conta", b =>
                {
                    b.Navigation("Transacoes");
                });
#pragma warning restore 612, 618
        }
    }
}

using Gestor.Financeiro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Systhem.Shop.Core.Data;

namespace Gestor.Financeiro.Data.Context
{
    public class FinanceiroContext : DbContext, IUnitOfWork
    {
        public DbSet<Transacao>? Transacoes { get; set; }
        public DbSet<Conta>? Contas { get; set; }

        public FinanceiroContext(DbContextOptions<FinanceiroContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinanceiroContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Financeiro.Data.Context
{
    public class FinanceiroContextFactory : IDesignTimeDbContextFactory<FinanceiroContext>
    {
        public FinanceiroContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FinanceiroContext>();
            optionsBuilder.UseNpgsql("Server=199.192.207.157;Port=5432;Database=transations;UserId=postgres;Password=Lj$ma*dM5027;");

            return new FinanceiroContext(optionsBuilder.Options);
        }
    }
}

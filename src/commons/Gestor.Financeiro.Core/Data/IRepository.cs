using Gestor.Financeiro.Core.CommonsObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Financeiro.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IEntityRoot
    {

    }
}

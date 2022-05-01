using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Financeiro.Core.Utils
{
    public static class StringToNumber
    {
        public static string ApenasNumeros(this string str, string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }
    }
}
